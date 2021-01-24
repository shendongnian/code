    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));
                services.AddDefaultIdentity<ContosoUniversityUser>()
                        .AddRoles<IdentityRole>() // Add IdentityRole to ServiceCollection
                        .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
  
