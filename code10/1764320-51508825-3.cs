    namespace MyIdentityServer.DataClassLibrary.DbContexts
    {
    public class MyTestDbContext : ConfigurationDbContext
    {
        public MyTestDbContext(DbContextOptions<ConfigurationDbContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("OnModelCreating invoking...");
            base.OnModelCreating(modelBuilder);
            // Map the entities to different tables here
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResource>().ToTable("mytesttable");
            Console.WriteLine("...OnModelCreating invoked");
        }
    }
    public class MyTestContextDesignTimeFactory : DesignTimeDbContextFactoryBase<MyTestDbContext>
    {
        public MyTestContextDesignTimeFactory()
            : base("IDPDataDBConnectionString", typeof(MyTestContextDesignTimeFactory).GetTypeInfo().Assembly.GetName().Name)
        {
        }
        protected override MyTestDbContext CreateNewInstance(DbContextOptions<MyTestDbContext> options)
        {
            var x = new DbContextOptions<ConfigurationDbContext>();
    
            Console.WriteLine("Here we go...");
            var optionsBuilder = newDbContextOptionsBuilder<ConfigurationDbContext>();
            optionsBuilder.UseNpgsql("IDPDataDBConnectionString", postGresOptions => postGresOptions.MigrationsAssembly(typeof(MyTestContextDesignTimeFactory).GetTypeInfo().Assembly.GetName().Name));
            DbContextOptions<ConfigurationDbContext> ops = optionsBuilder.Options;
            return new MyTestDbContext(ops, new ConfigurationStoreOptions());
        }
    }
    /* Enable these if you just want to host your data migrations in a separate assembly and use the IdentityServer supplied DbContexts 
    public class ConfigurationContextDesignTimeFactory : DesignTimeDbContextFactoryBase<ConfigurationDbContext>
    {
        public ConfigurationContextDesignTimeFactory()
            : base("IDPDataDBConnectionString", typeof(ConfigurationContextDesignTimeFactory).GetTypeInfo().Assembly.GetName().Name)
        {
        }
        protected override ConfigurationDbContext CreateNewInstance(DbContextOptions<ConfigurationDbContext> options)
        {
            return new ConfigurationDbContext(options, new ConfigurationStoreOptions());
        }
    }
    public class PersistedGrantContextDesignTimeFactory : DesignTimeDbContextFactoryBase<PersistedGrantDbContext>
    {
        public PersistedGrantContextDesignTimeFactory()
            : base("IDPDataDBConnectionString", typeof(PersistedGrantContextDesignTimeFactory).GetTypeInfo().Assembly.GetName().Name)
        {
        }
        protected override PersistedGrantDbContext CreateNewInstance(DbContextOptions<PersistedGrantDbContext> options)
        {
            return new PersistedGrantDbContext(options, new OperationalStoreOptions());
        }
    }
    */
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
    IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected string ConnectionStringName { get; }
        protected String MigrationsAssemblyName { get; }
        public DesignTimeDbContextFactoryBase(string connectionStringName, string migrationsAssemblyName)
        {
            ConnectionStringName = connectionStringName;
            MigrationsAssemblyName = migrationsAssemblyName;
        }
        public TContext CreateDbContext(string[] args)
        {
            return Create(
                Directory.GetCurrentDirectory(),
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                ConnectionStringName, MigrationsAssemblyName);
        }
        protected abstract TContext CreateNewInstance(
            DbContextOptions<TContext> options);
        public TContext CreateWithConnectionStringName(string connectionStringName, string migrationsAssemblyName)
        {
            var environmentName =
                Environment.GetEnvironmentVariable(
                    "ASPNETCORE_ENVIRONMENT");
            var basePath = AppContext.BaseDirectory;
            return Create(basePath, environmentName, connectionStringName, migrationsAssemblyName);
        }
        private TContext Create(string basePath, string environmentName, string connectionStringName, string migrationsAssemblyName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(@"c:\change\this\path\to\appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            var connstr = config.GetConnectionString(connectionStringName);
            if (String.IsNullOrWhiteSpace(connstr) == true)
            {
                throw new InvalidOperationException(
                    "Could not find a connection string named 'default'.");
            }
            else
            {
                return CreateWithConnectionString(connstr, migrationsAssemblyName);
            }
        }
        private TContext CreateWithConnectionString(string connectionString, string migrationsAssemblyName)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
             $"{nameof(connectionString)} is null or empty.",
             nameof(connectionString));
            var optionsBuilder =
                 new DbContextOptionsBuilder<TContext>();
            Console.WriteLine(
                "MyDesignTimeDbContextFactory.Create(string): Connection string: {0}",
                connectionString);
            optionsBuilder.UseNpgsql(connectionString, postGresOptions => postGresOptions.MigrationsAssembly(migrationsAssemblyName));
            DbContextOptions<TContext> options = optionsBuilder.Options;
            Console.WriteLine("Instancing....");
            return CreateNewInstance(options);
        }
    }
    }
