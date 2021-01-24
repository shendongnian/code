            try
            {
                var http = new HttpClient();
                var formContent = new HttpMultipartFormDataContent();
                var fileContent = new HttpStreamContent(await file.OpenReadAsync());
                fileContent.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("image/png");
                formContent.Add(fileContent, "files", "lockscreenlogo.png");
                var response = await http.PostAsync(new Uri("http://localhost:15924/api/values/Form"), formContent);
               response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
            }
