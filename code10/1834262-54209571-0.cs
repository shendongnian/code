    public class ValidFoo : ValidationAttribute
    {
        private readonly string _name;
        public ValidFoo(string name)
        {
            _name = name;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   
            
            if (!decimal.TryParse(...)) // if cannot parse / not valid
            {
                return new ValidationResult($"{_name} should be formatted as Currency, etc.");
            }
            
            // if we got this far it was a success
            return ValidationResult.Success;
        }        
    }
