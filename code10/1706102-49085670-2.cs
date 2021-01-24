    public void ConfigureServices(IServiceCollection services)
    {
         ...other code here removed for simplicity
         Services.AddTransient<IProfileService, ProfileService>();
         ...other code here removed for simplicity
    }
