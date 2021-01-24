    public void ConfigureServices(IServiceCollection services) {
        //...
        services
            .AddMvc()
            .ConfigureApplicationPartManager(apm => {
                var originals = apm.FeatureProviders.OfType<ControllerFeatureProvider>();
                foreach(var original in originals) {
                    apm.FeatureProviders.Remove(original);
                }
                apm.FeatureProviders.Add(new SingleControllerFeatureProvider(typeof(MySpecialController)));
            });
            
        //...
    }
    
