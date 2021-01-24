    using Microsoft.Extensions.Configuration;
    using System.IO;
    
    protected string ConnectionString { get; set; }
    public GetDBConnString()
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()) + "/").AddJsonFile("config.json", false)
				.Build();
			this.ConnectionString = configuration.GetSection("connectionString").Value;
		}
