    public class Startup
    {
      ......
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseRequestLocalization();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                    new CultureInfo("en-US"),
                    new CultureInfo("fa-IR"),
            };
            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("fa-IR","fa-IR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
       
            app.UseRequestLocalization(options);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
