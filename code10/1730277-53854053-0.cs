        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings:MyConnection:ConnectionString")));
            var builder = new ContainerBuilder();
            builder.Populate(services);
            //...
            // Your interface registration
            //...
            builder.Build(Autofac.Builder.ContainerBuildOptions.None);
        }
