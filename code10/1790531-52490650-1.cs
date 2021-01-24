            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/Identity/Account", map =>
            {
                map.Run(async context =>
                {
                    await context.Response.WriteAsync("");
                });
            });
