    [TableMapping("People")]
    public class Person
    {
      [ColumnMapping("fname")]
      public string FirstName {get; set;}
      
      [ColumnMapping("lname")]
      public string LastName {get; set;}
    }
