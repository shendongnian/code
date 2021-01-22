    var contentEncoding = response.Headers["content-encoding"];
                            if (contentEncoding != null && contentEncoding.Contains("gzip")) // cause httphandler only request gzip
                            {
                                // using gzip stream reader
                                using (var responseStreamReader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)))
                                {
                                    strResponse = responseStreamReader.ReadToEnd();
                                }
                            }
                            else
                            {
                                // using ordinary stream reader
                                using (var responseStreamReader = new StreamReader(response.GetResponseStream()))
                                {
                                    strResponse = responseStreamReader.ReadToEnd();
                                }
                            }
 
