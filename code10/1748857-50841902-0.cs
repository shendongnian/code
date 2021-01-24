    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<DatabaseSettings> settings)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        app.UseMvc();
        var databaseSettings = settings.Value;
        Mongo.Initialize("mongodb://" + databaseSettings.Hostname + ":" + databaseSettings.Port, databaseSettings.DbName);
    }
