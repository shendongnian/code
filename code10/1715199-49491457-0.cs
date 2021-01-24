     public class Child2
     {
      public int id { get; set; }
      public string name { get; set; }
      public int parentID { get; set; }
      public bool hasChildren { get; set; }
      public List<object> children { get; set; }
     }
    public class Child
     {
      public int id { get; set; }
      public string name { get; set; }
      public int paretnID { get; set; }
      public bool hasChildren { get; set; }
      public List<Child2> children { get; set; }
    }
    public class RootObject
    {
    public int id { get; set; }
    public string name { get; set; }
    public bool hasChildren { get; set; }
    public int parentID { get; set; }
    public List<Child> children { get; set; }
    }
