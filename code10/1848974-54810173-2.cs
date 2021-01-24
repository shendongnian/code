    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddHttpContextAccessor();
            services.AddDbContext<UniversityDbContext>(options
                => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestUniversity;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddScoped<IAuditHelper, AuditHelper>();
            ...
        }
        ...
    }
