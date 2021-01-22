     public class Customer 
    {
      public string Name { get; set; }
      public Address address{ get; set; }
      public AddressType type {get; set;}
    }
    public class Address 
    {
      public string Line1 { get; set; }
      public string Line2 { get; set; }
      public string Town { get; set; }
      public string County { get; set; }
      public string Postcode { get; set; }
   }
    public enum AddressType
    {
       HOME,
       WORK
    }
