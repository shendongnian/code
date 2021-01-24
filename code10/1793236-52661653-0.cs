    for (int i = 0; i < Postdata.Attachment_Path.Count; i++)
                    {
                        Mfdc = new MultipartFormDataContent();
                        StorageFile sfs = await StorageFile.GetFileFromPathAsync(Postdata.Attachment_Path[i]);
                         await Task.Run(async () => {
                             FileStream fs = File.OpenRead(sfs.Path);
                             var streamContent = new StreamContent(fs);
                             var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                             imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                             form.Add(imageContent, i.ToString(), Postdata.Attached_filename[i]);
                         });
                    }  
