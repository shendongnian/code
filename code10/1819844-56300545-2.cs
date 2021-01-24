    public override void ConfigureServices(IServiceCollection services)
    {
      ... other code omitted ...
      services.AddScoped<IHttpContextAccessor>(provider => new 
           LocalHttpContextAccessor(provider));
      ... other code omitted ...
    }
