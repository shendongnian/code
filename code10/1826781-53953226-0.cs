    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<string, SpeedType?>().ConvertUsing(speed =>
        {
            switch (speed)
            {
                case "M": return SpeedType.Manual;
                case "A": return SpeedType.Automatic;
                default: return SpeedType.Unknown;
            }
        });
    
        cfg.CreateMap<Range<string>, Range<SpeedType?>>();
        cfg.CreateMap<Vehicle, Motor>();
    });
    
    var vehicle = new Vehicle
    {
        Speed = new Range<string>
        {
            Min = "M",
            Max = "A"
        }
    };
    
    var motor = Mapper.Map<Vehicle, Motor>(vehicle);
