`
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
namespace Database
{
    public class Context : DbContext
    {
        public Context() : base()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\")
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddEnvironmentVariables()
                         .Build();
            ConnectionString = configuration.GetConnectionString("Database");
        }
        public string ConnectionString { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
