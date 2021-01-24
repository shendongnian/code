    public void ConfigureServices(IServiceCollection services) {
        //...
        services
            .AddMvc()
            .ConfigureApplicationPartManager(manager => {
                var originals = manager.FeatureProviders.OfType<ControllerFeatureProvider>();
                foreach(var original in originals) {
                    manager.FeatureProviders.Remove(original);
                }
                manager.FeatureProviders.Add(new SingleControllerFeatureProvider(typeof(MySpecialController)));
            });
            
        //...
    }
    
