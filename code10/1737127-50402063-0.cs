    public async Task MyJson()//void if not async
    {
        const string jsonUrl = "url-of-remote-json";
        HttpContext.Response.ContentType = "application/json";
        using (var streamWriter = new System.IO.StreamWriter(HttpContext.Response.Body/*response stream*/))
        {
            using (var client = new System.Net.WebClient())
            {
                try
                {
                    byte[] bytes = client.DownloadData(jsonUrl);
                    streamWriter.Write(bytes);
                }
                catch(Exception e)//404 or anything
                {
                    HttpContext.Response.StatusCode = 400;//BadRequest
                }
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }
        }
        //nothing to return
    }
