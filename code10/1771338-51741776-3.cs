    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.ComponentModel.DataAnnotations;    
    
    namespace MyProject.Models.Validation
    {
    
        public class SpecialCategoryAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
    
                if(value == 6 || value == 10)
                {
                    return ValidationResult.Success;
                }
    
    
                return new ValidationResult("Fail");
            }
        }
    }
