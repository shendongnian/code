    builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
    builder
        .RegisterType<AppDbContext>()
        .WithParameter("options", DbContextOptionsFactory.Get())
        .InstancePerLifetimeScope();
DbContextOptionsFactory
    public class DbContextOptionsFactory
    {
        public static DbContextOptions<AppDbContext> Get()
        {
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            DbContextConfigurer.Configure(builder, configuration.GetConnectionString(AppConsts.ConnectionStringName));
            return builder.Options;
        }
    }
DbContextConfigurer
    public class DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AppDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString).UseLazyLoadingProxies();
        }
    }
