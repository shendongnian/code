    public class MyCustomValidatorAttribute : ValidationAttribute
    {
        public bool override IsValid(Object value)
        {  
              var model = validationContext.ObjectInstance as MyModel; 
    		  // would probably use reflection and pass property names instead of casting in real life
    		  
    		  if (model.var2 != null && value == null)
    		  {
    			return new ValidationResult("var1 is required when var2 is set");
    		  }
    		  
    		  return ValidationResult.Success;
        }
    }
