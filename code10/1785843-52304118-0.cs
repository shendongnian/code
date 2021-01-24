    public class Info
    {
      public string prop1 {get;set;}
      public string prop2 {get;set;}
      public int prop3 {get;set;}
      public List<Dictionary<string, List<int>>> prop4 {get;set}
    }
    public class  Response
    {
      public class Dictionary<string, Info> Items {get;set;} // Should be named Items
    }
