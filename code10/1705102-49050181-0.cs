    private async Task DetectLanguage(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        var msg = await result;
            
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "PUT YOU KEY HERE");
        // Request parameters
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["numberOfLanguagesToDetect"] = "1";
        // HERE BE CAREFUL ABOUT THE REGION USED, IT MUST BE CONSISTENT WITH YOUR API KEY DECLARATION
        var uri = "https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0/languages?" + queryString;
        // Request body
        var serializer = new JavaScriptSerializer();
        var body = "{ \"documents\": [ { \"id\": \"string\", \"text\": " + serializer.Serialize(msg.Text) + " } ]}";
        var byteData = Encoding.UTF8.GetBytes(body);
        var responseString = "";
        using (var content = new ByteArrayContent(byteData))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(uri, content);
            responseString = await response.Content.ReadAsStringAsync();
        }
        // fish out the detected language code
        dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
        var languageInfo = jsonResponse["documents"][0]["detectedLanguages"][0];
        var returnText = "No language detected";
        if (languageInfo["score"] > (decimal) 0.5)
        {
            returnText = languageInfo["iso6391Name"].ToString();
        }
        await context.PostAsync(returnText);
        context.Wait(DetectLanguage);
    }
