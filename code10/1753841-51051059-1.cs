    using (var client = new HttpClient())
    {
        using (var content = new MultipartFormDataContent())
        {
            var values = new[]
            {
                new KeyValuePair<string, string>("metaData", JsonConvert.SerializeObject("[{'symbolicName':'DocumentTitle','dataType':'string','value':'Test CSEPF Document'}]"))
            };
            foreach (var keyValuePair in values)
            {
               content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
            }
        var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePart));
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = "Foo.txt"
        };
        content.Add(fileContent);
        var requestUri = "http://sslp852:9080/CSEPFCoreRestServices/addDocument";
        var result = client.PostAsync(requestUri, content).Result;
    }
}
