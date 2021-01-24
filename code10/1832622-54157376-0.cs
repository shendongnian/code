    public class Stuff
    {
      public List<Item> Items { get; set; }
    }
    
    public class Item
    {
      [Remote(action:"Validate", controller: "Account", 
          HttpMethod = "POST", 
          ErrorMessage = "Error",
          AdditionalFields = "Prop2,Prop3")]
      public string Prop1 { get; set; }
    
      public string Prop2 { get; set; }
      public string Prop3 { get; set; }
    }
