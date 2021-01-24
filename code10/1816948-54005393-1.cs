    // Add CORS
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAllOrigins",
                  builder =>
                  {
                    builder
                      .AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowCredentials()
                      .AllowAnyMethod()
                      .WithOrigins("http://localhost:4200");
                  });
      });
      // Add Azure SignalR
      services.AddSignalR().AddAzureSignalR();
