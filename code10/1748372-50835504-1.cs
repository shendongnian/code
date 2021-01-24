     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {           
            ... //settings and logging initialization
            app.Use((context, next) =>
            {
                context.Request.Scheme = "https";
                return next();
            });
            ... //all the rest middleware calls
        }
