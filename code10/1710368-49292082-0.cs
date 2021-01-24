    public Task<HttpResponseMessage> UploadAsFormDataContent(string url, byte[] image)
    {
        MultipartFormDataContent form = new MultipartFormDataContent
        {
            { new ByteArrayContent(image, 0, image.Length), "file", "pic.jpeg" }
        };
        HttpClient client = new HttpClient();
        return client.PostAsync(url, form);
    }
