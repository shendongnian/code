    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(opt =>
        {
            opt.UseInMemoryDatabase("TodoList").EnableSensitiveDataLogging();
        });
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
