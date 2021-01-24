    public class Entity
    {
      public ObjectId id;
      public string name { get; set; }
    }
    
    public class Other
    {
      public ObjectId id;
      public ObjectId entity { get; set; }
      public string name { get; set; }
    }
    
    public class EntityWithOthers
    {
      public ObjectId id;
      public string name { get; set; }
      public IEnumerable<Other> others;
    }
     public class EntityWithOther
    {
      public ObjectId id;
      public string name { get; set; }
      public Other others;
    }
