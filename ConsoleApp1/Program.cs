using System.Text;

using Newtonsoft.Json;
if (args.Length > 0)
{
    HttpClient client = new HttpClient();

    client.DefaultRequestHeaders.Add("authorization", "Bearer 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");

    var content = new StringContent("{\"model\": \"text-davinci-001\", \"prompt\": \"" + args[0] + "\",\"temperature\": 1,\"max_tokens\": 100}",
        Encoding.UTF8, "application/json");

    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);

    string responseString = await response.Content.ReadAsStringAsync();
try
{
    var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);

    Console.WriteLine(dyData?.choices[0].text);

}
catch (Exception ex)
{
    Console.WriteLine($" Could not deserialize the JSON: {ex.Message}");
}
}
else
{
    Console.WriteLine("Fals");
}


