    string responseData = Utilitycl.GetHtmlInputValue(getString, "responseData", Utilitycl.ELEMENTTYPE.INPUT);
    responseData = responseData.Replace("&amp;", "&");
    responseData = HttpUtility.UrlEncode(responseData);
    using (WebClient wc = new WebClient())
    {
        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        string HtmlResult = wc.UploadString("https://spiderenq.000webhostapp.com/test.php", "authRespCode=1&responseData = " + responseData);
    }
