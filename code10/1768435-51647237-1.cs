        public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CoreAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CoreAppContextConnection")));
                services.AddIdentity<ContosoUniversityUser, IdentityRole>()
                        .AddEntityFrameworkStores<CoreAppContext>();
            });
        }
    }
