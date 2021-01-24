    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var scopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
    
            // ...
    
            app.Use(async (context,next) =>
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var request = new Request(context);
                    var response = new Response(context);
    
                    await scope.ServiceProvider.GetRequiredService<IRequestFactory>().ProcessAsync(request, response);
                }
              await next.Invoke()
            });
           app.UseMvc();
        }
