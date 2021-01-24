    private async void BeginUpdate(bool webserverStatus)
    {
        if (!webserverStatus) return;
        
        var byteArray  = File.ReadAllBytes("myUpdatePackage.zip");
        var httpClient = new HttpClient();
        var form       = new MultipartFormDataContent();
        form.Add(new ByteArrayContent(byteArray, 0, byteArray.Length), "myUpdatePackage", "myUpdatePackage.zip");
        HttpResponseMessage response = await httpClient.PutAsync(@"http://localhost:9000/api/file/", form);
        response.EnsureSuccessStatusCode();
        httpClient.Dispose();
        string sd = response.Content.ReadAsStringAsync().Result;
    }
