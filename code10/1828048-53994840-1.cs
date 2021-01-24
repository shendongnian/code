    public async override Task Invoke(IOwinContext context) {
        // hold a reference to what will be the outbound/processed response stream object 
        var stream = context.Response.Body;
        // create a stream that will be sent to the response stream before processing
        using (var buffer = new MemoryStream()) {
             // set the response stream to the buffer to hold the unaltered response
            context.Response.Body = buffer;
            // allow other middleware to respond
            await Next.Invoke(context);
            // we have the unaltered response, go to start
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
