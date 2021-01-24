c#
public static HttpResponseMessage getBack(HttpClient client)
{
    var values = new Dictionary<string, string>
    {
        { "folderPath", @"C:\Temp" }
    };
    var content = new FormUrlEncodedContent(values);
    return client.PostAsync("Home/saveDocumentToPath", content).GetAwaiter().GetResult();
}
You won't even need the `client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));` in your client, since you're not posting json.
