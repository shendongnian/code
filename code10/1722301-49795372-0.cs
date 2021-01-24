    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage response = await client.GetAsync(item.ContentUrl))
                        using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                        {
                            await targetBlob.UploadFromStreamAsync(streamToReadFrom);
                        }
                    }
