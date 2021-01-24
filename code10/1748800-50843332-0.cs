    public async Task<bool> UploadAsync(string path, string fileName, byte[] data)
    {
        EnforceBasicAuthentication();
        var bytesContent = new ByteArrayContent(data);
        bytesContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
        bytesContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"file\"",
            FileName = $"\"{fileName}\""
        };
        var formData = new MultipartFormDataContent { bytesContent };
        var boundary = formData.Headers.ContentType.Parameters.First(o => o.Name == "boundary");
        boundary.Value = boundary.Value.Replace("\"", string.Empty);
        var response = await _httpClient.PostAsync($"{_config.FtpUrl}/path/data/{_config.FtpPath}/{path}", formData);
        response.EnsureSuccessStatusCode();
        return true;
    }
