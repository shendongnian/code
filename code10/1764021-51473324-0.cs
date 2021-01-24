    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();
    
            var host = BuildWebHost(args);
    
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    using (var context = new ApplicationDbContext(
                    services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
                	{
    	            	context.Provinces.Add(new Models.Province
    	                {
    	                    ID = 1,
    	                    Name = "TEST"
    	                });
    	                context.SaveChanges();
                	}
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured while seeding the database.");
                }
            }
    
            host.Run();
        }
    
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
