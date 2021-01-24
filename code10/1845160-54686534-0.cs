    CreateMap<Location, LocationEntity>().ReverseMap().ForCtorParam("geoLocation", o=>o.MapFrom(s=>s));
    
    class LocationEntity
    {
    public LocationEntity(string name, double geoLocationLatitude, double geoLocationLongitude)
    {
        this.Name = name;
        this.Latitude = geoLocationLatitude;
        this.Longitude = geoLocationLongitude;
    }
    public string Name { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    }
