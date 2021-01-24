    public async override Task Invoke(IOwinContext context)
    {
        var stream = context.Response.Body;
        using (var buffer = new MemoryStream())
        {
            context.Response.Body = buffer;
            await Next.Invoke(context);
            buffer.Seek(0, SeekOrigin.Begin);
            var byteArray = Encoding.ASCII.GetBytes("Hello World");
            context.Response.StatusCode = 200;
            context.Response.ContentLength = byteArray.Length;
            buffer.SetLength(0);
            buffer.Write(byteArray, 0, byteArray.Length);
            buffer.Seek(0, SeekOrigin.Begin);
            buffer.CopyTo(stream);
            //replace the body stream
            context.Response.Body = stream;
        }
    }
