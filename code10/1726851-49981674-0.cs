    using Microsoft.Extensions.Configuration;
    using System.IO;
        public BaseDal()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            var _connectionString = Configuration.GetConnectionString("CONNECTION_STRING")
        }
