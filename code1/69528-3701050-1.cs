    public class Ship : MPropertyAsStringSettable {
      public Latitude Latitude { get; set; }
      // ...
    }
    [TypeConverter(typeof(LatitudeConverter))]
    public class Latitude { ... }
