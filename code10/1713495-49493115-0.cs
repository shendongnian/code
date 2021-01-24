    async static Task<string> readMultipart(HttpWebResponse httpResponse)
            {
                var content = new StreamContent(httpResponse.GetResponseStream());
                content.Headers.Add("Content-Type", httpResponse.ContentType);
    
    
                MultipartMemoryStreamProvider multipart = new MultipartMemoryStreamProvider();
                Task.Factory.StartNew(() => multipart = content.ReadAsMultipartAsync().Result,
                   CancellationToken.None,
                   TaskCreationOptions.LongRunning, // guarantees separate thread
                   TaskScheduler.Default)
                   .Wait();
                String filename = "";
                String json = await multipart.Contents[0].ReadAsStringAsync();
    
                
                string path = HttpContext.Current.Server.MapPath("/test.jpeg");
                byte[] fileData = multipart.Contents[1].ReadAsByteArrayAsync().Result;
                System.IO.File.WriteAllBytes(path, fileData);
                return json;
            }
