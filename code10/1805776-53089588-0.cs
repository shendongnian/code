    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    public class MyModel
    {
    
      public int? ID { get; set; }
    
      [Required(ErrorMessage = "Name can not be blank")]
      [ExampleValidation]
      public string Name { get; set; }
    
    }
    
    public class ExampleValidation : ValidationAttribute
    {
    
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
          var _context = (ApplicationDbContext)validationContext
                             .GetService(typeof(ApplicationDbContext));
          /* my query here using the _context, and if necessary, apply the error message below: */
          return new ValidationResult("My error message here");
        }
    
      }
    }
