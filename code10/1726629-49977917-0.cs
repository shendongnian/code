      public async Task<string> UploadFile(string actionUrl, string filePath)
            {
                var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMilliseconds(FileReqTimeout);
             
                FileStream fileStream = File.OpenRead(filePath);
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                streamContent.Headers.ContentDisposition.Name = "\"firmfile\"";
                streamContent.Headers.ContentDisposition.FileName = "\"" + Path.GetFileName(filePath) + "\"";
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                string boundary = Guid.NewGuid().ToString();
                var content = new MultipartFormDataContent(boundary);
                content.Headers.Remove("Content-Type");
                content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
                content.Add(streamContent);
                HttpResponseMessage response = null;
                try
                {
                    response = await httpClient.PostAsync(actionUrl, content, cts.Token);
                }
                catch (WebException ex)
                {
                    // handle web exception
                    return null;
                }
                catch (TaskCanceledException ex)
                {
                    if (ex.CancellationToken == cts.Token)
                    {
                        // a real cancellation, triggered by the caller
                        return null;
                    }
                    else
                    {
                        // a web request timeout (possibly other things!?)
                        return null;
                    }
                }
    
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception)
                {
                    return null;
                };
    
                string res = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => res);
            }
        }
