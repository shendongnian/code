    public async Task Invoke(IDictionary<string, object> env) {
        IOwinContext context = new OwinContext(env);
        // Buffer the response
        var stream = context.Response.Body;
        using (var buffer = new MemoryStream()) {
            context.Response.Body = buffer;
            //call next in pipeline
            await this.next(env);
            //reset the original response body
            context.Response.Body = stream;
    
            //get data from buffer
            buffer.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(buffer);
            string responseBody = await reader.ReadToEndAsync();    
            buffer.Seek(0, SeekOrigin.Begin);
            //put data into original stream to continue the flow.
            await buffer.CopyToAsync(stream);
        }
       
    }
