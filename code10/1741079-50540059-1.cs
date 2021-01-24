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
      public List<Other> others;
    }
