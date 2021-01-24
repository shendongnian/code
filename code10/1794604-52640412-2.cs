    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YourAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is Dictionary<string, string>))
                return new ValidationResult("Object is not of proper type");
            var dictionary = (Dictionary<string, string>)value;
            if (dictionary.Count > 10)
                return new ValidationResult("Dictionary cant have more than 10 items");
            foreach (var keyValuePair in dictionary)
            {
                if (keyValuePair.Value.Length > 256)
                    return new ValidationResult("Value cant be longer than 256.");
            }
            return ValidationResult.Success;
        }
    }
