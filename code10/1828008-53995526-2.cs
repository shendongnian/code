    class TrialObject
        {
            [JsonConverter(typeof(TypeInfoConverter))]
            public String szObject = "trial string";
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public Double doubleObject = 999999999.999;
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public Boolean boolObject = true;
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public DateTime dateObject = DateTime.Now;
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public GeoPoint geoPointObject = new GeoPoint() { Latitude = 123456789.123456, Longitude = 123456789.123456 };
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public Dictionary<string, string> mapObject = new Dictionary<string, string>();
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public Dictionary<string, List<GeoPoint>> mapObjectEx = new Dictionary<string, List<GeoPoint>>()
                {{ "1", new List<GeoPoint>() { new GeoPoint() { Latitude = 0.0, Longitude = 0.0 } } }};
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public List<GeoPoint> points = new List<GeoPoint>()
                { new GeoPoint() { Latitude=0.0, Longitude=0.0 } };
    
            [JsonConverter(typeof(TypeInfoConverter))]
            public Rating rating = Rating.Good;
        }
    
        class GeoPoint
        {
            public double Latitude;
            public double Longitude;
        }
    
        enum Rating
        {
            Good,
            Bad,
        }
