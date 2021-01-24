    public class Item
    {
      public string name { get; set; }
      public string displayName { get; set; }
      public string description { get; set; }
      public bool isStatic { get; set; }
      public List<string> permissions { get; set; }
      public int id { get; set; }
     }
    
     public class Result
     {
       public List<Item> items { get; set; }
     }
    
     public class RootObject
     {
       public Result result { get; set; }
       public object targetUrl { get; set; }
       public bool success { get; set; }
       public object error { get; set; }
       public bool unAuthorizedRequest { get; set; }
       public bool __abp { get; set; }
     }
