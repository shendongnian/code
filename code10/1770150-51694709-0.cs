    public class UpperCaseAttribute: System.ComponentModel.DataAnnotations.ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string suppliedValue = (string)value;
                var hasUpperChar = new Regex(@"[A-Z]+");
                var match = hasUpperChar.IsMatch(suppliedValue);
                if (match == false)
                {
                return new ValidationResult("Input Should Have Uppercase ");
                }
            }
            return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            AttributeUtils.MergeAttribute(context.Attributes, "data-val", "true");
            AttributeUtils.MergeAttribute(context.Attributes, "data-val-uppercase", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
        }
    }
