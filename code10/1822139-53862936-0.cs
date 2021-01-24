    public override WebResourceResponse ShouldInterceptRequest(WebView view, IWebResourceRequest urlResource)
    {
        if (!urlResource.RequestHeaders.ContainsKey("mysource"))
        {
            urlResource.RequestHeaders.Add("mysource", "app");
        }
        var client = new HttpClient();
        var result = client.GetAsync(urlResource.Url,ToString()).Result;
        string contentType = result.Content.Headers.ContentType.ToString();
        var stream = result.Content.ReadStreamAsync().Result;
        return new WebResourceResponse("text/html", "charset=utf-8", (int)result.StatusCode, result.ReasonPhrase, urlResource.RequestHeaders, stream);
    }  
