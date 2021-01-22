    public class Person : IValidatableObject
    {
        public string Name { get; set; }
        public bool IsSenior { get; set; }
        public Senior Senior { get; set; }
     
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        { 
         if (IsSenior && string.IsNullOrEmpty(Senior.Description)) 
            yield return new ValidationResult("Description must be supplied.");
        }
    }
     
