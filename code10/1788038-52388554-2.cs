    public void Configure(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var seedDataService = scope.ServiceProvider.GetRequiredService<ISeedDataService>();
            // Use seedDataService here
        }
    }
