    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.Use(async (httpContext, next) =>
            {
                var request = httpContext.Request;
                if (request.Method == HttpMethods.Post || request.Method == HttpMethods.Put && request.Body.CanRead)
                {
                    //Allows re-usage of the stream
                    request.EnableBuffering();
                    request.Body.Seek(0, SeekOrigin.Begin);
                    using (var stream = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
                    {
                        var body = await stream.ReadToEndAsync();
                        //Reset the stream so data is not lost
                        request.Body.Position = 0;
                        var bodyFeature = new RequestBodyFeature(body); // RequestBodyFeature is a simple POCO
                        httpContext.Features.Set(bodyFeature);
                    }
                    request.Body.Seek(0, SeekOrigin.Begin);
                }
                await next.Invoke();
            });
            app.UseMvc();
    }
