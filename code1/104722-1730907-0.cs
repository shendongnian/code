    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/x-gzip";
        var xml = "<xml/>";
        using (var gzipStream = new GZipStream(context.Response.OutputStream, CompressionMode.Compress))
        {
            var buffer = Encoding.UTF8.GetBytes(xml);
            gzipStream.Write(buffer, 0, buffer.Length);
        }
    }
