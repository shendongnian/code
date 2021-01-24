    static HttpClient client = new HttpClient();
    client.Timeout = TimeSpan.FromMinutes(60);
    
        static async Task<bool> UploadLargeObjectAsync(string presignedUrl, string file)
        {
            Console.WriteLine("Uploading " + file + " to bucket...");          
            try
            {
                StreamContent strm = new StreamContent(new FileStream(file, FileMode.Open, FileAccess.Read));
                strm.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                HttpResponseMessage putRespMsg = await client.PutAsync(presignedUrl, strm);              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
            return true;
        }
