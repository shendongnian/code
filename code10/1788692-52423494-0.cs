     using (MemoryStream stream = new System.IO.MemoryStream())
                {
                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(stream.ToArray())
                    };
                    result.Content.Headers.ContentDisposition =
                        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                        {
                            FileName = data.Name + MimeTypeMap.GetExtension(data.MimeType)
                        };
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue(data.MimeType);
                    var response = ResponseMessage(result);
                    return response;
                }
