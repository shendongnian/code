    public class Order 
    {
      public string MaterialName { get; set; }
      public int MaterialType { get; set; } // consider making this an Enum
      public string MaterialDescription { get; set; }
      public List<Dictionary<string, string>> Roles { get; set; }
    }
