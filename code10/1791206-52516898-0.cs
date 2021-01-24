    public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(DbContext), typeof(NorthwindContext));
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<NorthwindContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
            return services;
        }
