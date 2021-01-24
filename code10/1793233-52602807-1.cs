        //using Windows.Web.Http.HttpClient 
        public async Task<bool> ShareStatusWithPicture(string text, StorageFile file)
        {
            Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient();
            var fileContent = new HttpStreamContent(await file.OpenAsync(FileAccessMode.Read));
            fileContent.Headers.Add("Content-Type", "multipart/form-data");
            
            var content = new HttpMultipartFormDataContent();
            Uri uri = new Uri("URI of your server");
            content.Add(fileContent, "pic", file.Name);
            content.Add(new HttpStringContent(tokens.AccessToken), "access_token");
            content.Add(new HttpStringContent("homework"), "status");
            //TO DO 
            //Add other HttpStringContent
            Windows.Web.Http.HttpResponseMessage msg = await client.PostAsync(uri, content);
            client.Dispose();
            return msg.IsSuccessStatusCode;
        }
