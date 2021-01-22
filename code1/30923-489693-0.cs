    public class Item
    {
      public string Name{ get; set; }
      // Here put all the properties that are common to all items.
    }
    
    public class Cupcake : Item
    {
      // By inheriting from Item, it will have Name 
      //  along with anything else you define there
    
      public bool HasFrosting{ get; set; }
      // Put whatever else Cupcake needs here
    }
    
    public class Baloon : Item
    {
      public Color MyColor{ get; set; }
    }
