    public static async Task<Size> GetUrlImageSizeAsync(string url)
    {
        try
        {
            var request = WebRequest.Create(url);
            request.Headers.Set(HttpRequestHeader.UserAgent, "Range: bytes=0-32");
    
            var size = new Size();
            using (var response = await request.GetResponseAsync())
            {
                var ms = new MemoryStream();
                var stream = response.GetResponseStream();
                stream.CopyTo(ms);
    
                var img = Image.FromStream(ms);
                size = img.Size;
            }
    
            return size;
        }
        catch
        {
            return new Size();
        }
    }
