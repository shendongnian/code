    using (var client = new HttpClient(handler) {BaseAddress = new Uri(_host)})
                {
                    var requestContent = new MultipartFormDataContent();
                    var fileContent = new StreamContent(fileInfo.OpenRead());
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            Name = "\"file\"",
                            FileName = "\"" + fileInfo.Name + "\""
                        };
                    fileContent.Headers.ContentType =
                        MediaTypeHeaderValue.Parse(MimeMapping.GetMimeMapping(fileInfo.Name));
                    var folderContent = new StringContent(folderId.ToString(CultureInfo.InvariantCulture));
    
                    requestContent.Add(fileContent);
                    requestContent.Add(folderContent, "\"folderId\"");
    
                    var result = client.PostAsync("Company/AddFile", requestContent).Result;
                }
