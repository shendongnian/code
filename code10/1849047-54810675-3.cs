    public void ConfigureServices(IServiceCollection services)
    {       
        var configOptionsRDStation = Configuration.GetSection("RDStationOptions : Url");
        var _rdStationInstance = new RDStationService(configOptionsRDStation.Value);
        services.AddSingleton(_rdStationInstance);
    }
