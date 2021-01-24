    public async Task OnRequest(object sender, SessionEventArgs e)
    {
        Console.WriteLine(e.WebSession.Request.Url);
        var requestHeaders = e.WebSession.Request.Headers;
        var method = e.WebSession.Request.Method.ToUpper();
        if ((method == "POST" || method == "PUT" || method == "PATCH"))
        {
            byte[] bodyBytes = await e.GetRequestBody();
            e.SetRequestBody(bodyBytes);
            string bodyString = await e.GetRequestBodyAsString();
            e.SetRequestBodyString(bodyString);
            e.UserData = e.WebSession.Request;
        }
    }
