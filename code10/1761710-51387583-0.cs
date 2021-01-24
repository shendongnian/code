    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICustomer>(provider => {
            var settings = Configuration.GetSection("ApiClientHttpSettings").Get<ApiClientHttpSettings>();
            return new Customer(settings.Name, settings.Age);
        });
    }
