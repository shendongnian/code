    HttpClientObject = new HttpClient(new HttpClientHandler 
    { AutomaticDecompression = DecompressionMethods.GZip, 
    ClientCertificateOptions = ClientCertificateOption.Automatic, 
    Credentials = new NetworkCredential(username, password, domain) });
    HttpClientObject.BaseAddress = new Uri(url);
    HttpClientObject.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html,application/xhtml+xml,application/xml"));
    HttpResponseMessage response = HttpClientObject.GetAsync();
