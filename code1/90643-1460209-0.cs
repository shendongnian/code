    WebClient webClient = new WebClient();
    using (webClient)
    {
       requestInterceptor.OnRequest(webClient);
       var enc = new ASCIIEncoding();
       return enc.GetString(webClient.UploadData(uri, enc.GetBytes(dataAsString)));
    }
