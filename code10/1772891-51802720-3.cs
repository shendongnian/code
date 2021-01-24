    public class Person {
      public string Name { get; set; }
      public Address Address { get; set; }
    }
    public class Address {
      public string Street { get; set; }
      public string City { get; set; }
      public Person HouseOwner { get; set; } // <- circular property
    }
