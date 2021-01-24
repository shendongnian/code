    public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc(options =>
                {
                    // This works
                    //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    
                    // These variants don't work
                    //options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                    options.Filters.Add(typeof(AutoValidateAntiforgeryTokenAttribute));
                });
    
                services.AddScoped<AutoValidateAntiforgeryTokenAttribute>();
            }
