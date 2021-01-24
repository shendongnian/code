    public readonly struct Location
    {
       public DateTime TimeStamp { get; }
       public Decimal Lat { get; }
       public Decimal Lon { get; }
    
       public Location(DateTime timeStamp, decimal lat, decimal lon)
       {
          TimeStamp = timeStamp;
          Lat = lat;
          Lon = lon;
       }
    }
