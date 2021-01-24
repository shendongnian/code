            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.EntityFrameworkCoreSink(app.ApplicationServices)
                                .CreateLogger();
            loggerFactory.AddSerilog();
