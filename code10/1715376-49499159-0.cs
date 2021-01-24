    public class MyModel
    {
      public double UnixDateTime { get; set; }
    
      public DateTime GregorianDateTime => new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(UnixDateTime)
                    .ToLocalTime();
    }
