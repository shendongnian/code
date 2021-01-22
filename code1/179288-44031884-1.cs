    [AttributeUsage(AttributeTargets.Property)]
    class ValidEmailAddressIfTrueAttribute : ValidationAttribute
    {
        private readonly string _nameOfBoolProp;
        public ValidEmailAddressIfTrueAttribute(string nameOfBoolProp)
        {
            _nameOfBoolProp = nameOfBoolProp;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                return null;
            }
            var property = validationContext.ObjectType.GetProperty(_nameOfBoolProp);
            if (property == null)
            {
                return new ValidationResult($"{_nameOfBoolProp} not found");
            }
            var boolVal = property.GetValue(validationContext.ObjectInstance, null);
            if (boolVal == null || boolVal.GetType() != typeof(bool))
            {
                return new ValidationResult($"{_nameOfBoolProp} not boolean");
            }
            if ((bool)boolVal)
            {
                var attribute = new EmailAddressAttribute {ErrorMessage = $"{value} is not a valid e-mail address."};
                return attribute.GetValidationResult(value, validationContext);
            }
            return null;
        }
    }
