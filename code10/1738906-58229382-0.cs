.json
  {
  "AllowedOrigins": "http://localhost:8080;http://localhost:3000"
  }
startup.cs
c#
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext dbContext, IOptions<AppSettings> appSettings)
if (!String.IsNullOrEmpty(_appSettings.AllowedOrigins))
       {
          var origins = _appSettings.AllowedOrigins.Split(";");
          app.UseCors(x => x
                    .WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader());
       }
