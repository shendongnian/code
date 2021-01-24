    public class EFDesignTimeService : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            new EntityFrameworkRelationalServicesBuilder(services).TryAddProviderSpecificServices(x =>
            {
                x.TryAddSingleton<INpgsqlOptions, NpgsqlOptions>(p =>
                {
                    var dbOption = new DbContextOptionsBuilder()
                        .UseNpgsql("connection string",
                            ob => ob.UseNodaTime().UseNetTopologySuite()).Options;
                    var npgOptions = new NpgsqlOptions();
                    npgOptions.Initialize(dbOption);
                    return npgOptions;
                });
            });
        }
    }
