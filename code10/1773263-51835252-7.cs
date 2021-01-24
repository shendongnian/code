    public void Configuration(IAppBuilder app, Helpers.SeedHelpers seed)
    {
        ConfigureAuth(app);
        seed.Seed().Wait();
    }
