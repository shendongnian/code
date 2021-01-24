        private static SiteService _siteService;
        private static ApplicationDbContext _appDbContext;
      
        public static void Main()
        {
            var services = new ServiceCollection();                      
                   
            services.AddTransient<ISiteInterface, SiteRepo>();
            services.AddTransient<SiteService>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("blah-blah"));            
            var serviceProvider = services.BuildServiceProvider();                                             
            _siteService = serviceProvider.GetService<SiteService>();
            _appDbContext = serviceProvider.GetService<ApplicationDbContext>();    
            GetData();
        }
