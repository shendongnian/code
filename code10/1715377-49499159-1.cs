    public class MyModel
    {
      public long UnixDateTime { get; set; }
    
      public DateTime GregorianDateTime { get { return new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(UnixDateTime); } }
    }
