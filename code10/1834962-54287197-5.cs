    public void ConfigureServices(IServiceCollection services) 
    {
        services.AddTransient(sa);
        services.AddTransient<Sb>(provider =>
        {
            var sa = provider.GetRequiredService<Sa>();
            var token = sa.GrantToken();
            return new Sb(token);
        });
    }
