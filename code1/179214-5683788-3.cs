    public class Product 
    {  
      [Key, Column(Order=0)]
      public string ShortDescription {get;set;} 
      [Key, Column(Order=1)]
      public string UserName {get;set;} 
    }
