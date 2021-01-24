    public class Startup {
        
        public Startup(IHostingEnvironment env) {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
    
            Configuration = builder.Build();
        }
    
        static IConfiguration Configuration { get; set; }
    
        public void ConfigureServices(IServiceCollection services) {    
   
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserDatabase"));
            );
    
            //...
        }
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
    
            app.UseBlazor<Client.Program>();
        }
    }
