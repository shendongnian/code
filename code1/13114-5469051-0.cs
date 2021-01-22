    using System.ComponentModel.DataAnnotations;
    public class Person
    {
         [StringLength(255, ErrorMessage = "Error")]
         public string FirstName { get; set; }
         [StringLength(255, ErrorMessage = "Error")]
         public string LastName { get; set; }
    }
