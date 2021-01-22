    string pageSource;
    string getUrl = "the url of the page behind the login";
    WebRequest getRequest = WebRequest.Create(getUrl);
    getRequest.Headers.Add("Cookie", cookieHeader);
    WebResponse getResponse = getRequest.GetResponse();
    using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
    {
        pageSource = sr.ReadToEnd();
    }
