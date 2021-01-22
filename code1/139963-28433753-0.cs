    public class Person {
      [Required]
      public String Name { get; set; }
    
      [Required, ValidateObject]
      public Address Address { get; set; }
    }
