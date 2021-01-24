    string fileURI = System.Web.HttpUtility.UrlEncode(filePath);
    WebClient webClient = new WebClient();
    using (Stream stream = webClient.OpenRead(fileURI))
    {
        ...
    }
