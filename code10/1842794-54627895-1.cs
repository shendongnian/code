            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication();
            app.Use(async (context, next) =>
            {
                //Retrieve claims from database based on roles in token.
                // Add to loaded identity    (= context.User)           
                
                await next.Invoke();
            });
