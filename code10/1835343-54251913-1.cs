    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        try
        {
            HttpWrapper wrapper = new HttpWrapper();
            services.AddTransient(provider => wrapper);
            ServiceProvider prov = services.BuildServiceProvider();
            HttpWrapper returned = prov.GetRequiredService<HttpWrapper>();
            Console.WriteLine("No problem");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
