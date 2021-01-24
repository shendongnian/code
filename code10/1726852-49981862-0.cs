      public class AppSettings
        {
            public string MsSqlConnectionString{ get; set; }
        }
       //registering in ConfigureServices method of Startup.cs
       services.Configure<AppSettings>(Configuration.GetSection("ConnectionStrings"));
