    services.Configure<RestaurantConfiguration>(c => {
        var config = Configuration.GetSection($"{restaurantNumber}/FOEConfiguration");
        c.TimeoutInMs = config.GetValue<int>("FOE.TimeoutInMs");
        // etc.
    });
