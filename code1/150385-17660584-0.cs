    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class ComparePassword: ValidationAttribute
    {
        public ComparePassword() 
            : base("Passwords must match.") { }
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("A password is required.");
            // Make sure you change YourRegistrationModel to whatever  the actual name is
            if ((validationContext.ObjectType.Name != "YourRegistrationModel") 
                 return new ValidationResult("This attribute is being used incorrectly.");
            if (((YourRegistrationModel)validationContext.ObjectInstance).ConfirmPassword != value.ToString())
                return new ValidationResult("Passwords must match.");
            return ValidationResult.Success;
        }
    }
