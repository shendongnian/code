    private System.IO.Stream Upload(string actionUrl, string paramString, Stream paramFileStream, byte [] paramFileBytes)
    {
        HttpContent stringContent = new StringContent(paramString);
        HttpContent fileStreamContent = new StreamContent(paramFileStream);
        HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
        using (var client = new HttpClient())
        using (var formData = new MultipartFormDataContent())
        {
            formData.Add(stringContent, "param1", "param1");
            formData.Add(fileStreamContent, "file1", "file1");
            formData.Add(bytesContent, "file2", "file2");
            var response = client.PostAsync(actionUrl, formData).Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStreamAsync().Result;
        }
    }
