    public HttpResponseMessage Get()
            {
                string filename = @"c:\sampl.zip";
    
                var response = this.Request.CreateResponse();
    
                response.Content = new PushStreamContent(async (Stream outputStream, HttpContent content, TransportContext context) =>
                {
                    try
                    {
                        var buffer = new byte[65536];
    
                        using (var video = File.Open(filename, FileMode.Open, FileAccess.Read))
                        {
                            var length = (int)video.Length;
                            var bytesRead = 1;
    
                            while (length > 0 && bytesRead > 0)
                            {
                                bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                                await outputStream.WriteAsync(buffer, 0, bytesRead);
                                length -= bytesRead;
    
                            }
                        }
                    }
                    finally
                    {
                        outputStream.Close();
                    }
                });
               
                return response;
            }
  
