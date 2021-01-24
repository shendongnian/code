        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //load the assembly from the view dll you have
            Assembly assempbly2 = AssemblyLoadContext.Default.LoadFromAssemblyPath("C:/the/path/to/your/solution.Views.dll");
            //register the views in razor view engine 
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(assempbly2));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
