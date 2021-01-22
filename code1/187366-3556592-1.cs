    using System.ComponentModel.DataAnnotations;
    public class Person
    {
       public string FirstName {get;set;}
    
       [Range(0, 110, ErrorMessage = "<your error message>")]
       public int Age {get;set;}
    }
