    public void ConfigureServices(IServiceCollection services)
    {
        // ... the existing code
        // Register the notes repository as a service
        services.AddScoped<NotesRepository>();
    }
