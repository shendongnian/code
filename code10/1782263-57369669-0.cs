    public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", //this v was in caps earlier
                new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",//this v was in caps earlier
                    Title = "Tiny Blog API",
                    Description = "A simple and easy blog which anyone love to blog."
                });
            });
            //Other statements
        }
