      public void ConfigureServices(IServiceCollection services)
            {
      //add cors service
                services.AddCors(options => options.AddPolicy("Cors",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }));
