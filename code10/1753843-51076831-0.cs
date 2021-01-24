     #region FILENET Upload
        string FileLocation = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["FileLocation"]);
        var FileNetRestServiceURL = "http://xxx:xx/FileNetCoreRestServices/AddDocument";
    
    using (var client = new HttpClient())
    {
        using (var content = new MultipartFormDataContent())
        {
            //Working - Default Values
            //var values = new[]
            //{new KeyValuePair<string, string>("metaData", "[{'symbolicName':'DocumentTitle','dataType':'string','value':'Test CSEPF Document'}]")};
    
            //Real Values
            var values = new[]
            {new KeyValuePair<string, string>("metaData", "[{'symbolicName':'"+Path.GetFileNameWithoutExtension(FileLocation).ToString()+"','dataType':'string','value':'"+Path.GetFileNameWithoutExtension(FileLocation).ToString()+"'}]")};
    
            //Convert the file into ByteArrayContent as the service is expecting a file object
            content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(FileLocation)), "file", Path.GetFileName(FileLocation).ToString());
    
            foreach (var keyValuePair in values)
            {
                content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
            }
    
            var response = client.PostAsync(FileNetRestServiceURL, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
    #endregion
