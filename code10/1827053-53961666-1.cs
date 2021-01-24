    internal Car(string Manufacturer, string CarModel)
    {
        Mfg = Manufacturer;
        Model = CarModel;
        TerrainType = Terrain.Land;
    }
    internal ImmutableCar(string Manufacturer, string CarModel) : base (Manufacturer, CarModel)
    {
    }
