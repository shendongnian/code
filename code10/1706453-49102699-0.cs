    private HttpClient httpClient = new HttpClient();
    private async void UploadFile_Cliked(object sender, EventArgs e) {
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(_mediaFile.GetStream()),
            "\"file\"",
            $"\"{_mediaFile.Path}\"");        
        var uploadServiceBaseAddress = "http://192.168.137.1/pic/";
        var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
        RemotePathLabel.Text = await httpResponseMessage.Content.ReadAsStringAsync();
    }
