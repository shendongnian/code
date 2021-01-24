        public async Task<IActionResult> MyJson()
        {
            const string jsonUrl = "url-to-json";
            HttpContext.Response.ContentType = "application/json";
            using (var client = new HttpClient())
            {
                try
                {
                    byte[] bytes = await client.GetByteArrayAsync(jsonUrl);
                    //write to response stream aka Response.Body
                    await HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                    await HttpContext.Response.Body.FlushAsync();
                    HttpContext.Response.Body.Close();
                }
                catch (Exception e)
                {
                    return new BadRequestResult();
                }
            }
            return new BadRequestResult();
        }
