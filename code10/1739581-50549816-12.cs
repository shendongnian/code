    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        var container = new YourContainer(); // Castle, Ninject, etc.
        // registrations into container
        return new YourContainerAdapter(container);
    }
