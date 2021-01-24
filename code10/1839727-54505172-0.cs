    app.Use(async (context, next) =>
    {
        context.Request.EnableRewind();
        var stream = context.Request.Body;
        
        using (var reader = new StreamReader(stream))
        {
            var requestBodyAsString = await reader.ReadToEndAsync();
            
            if (stream.CanSeek)
            	stream.Seek(0, SeekOrigin.Begin);
            
            //Do some thing
            
            await next.Invoke();
            
            var responseStatusCode = context.Response.StatusCode;
            //Do some other thing
        }
    });
