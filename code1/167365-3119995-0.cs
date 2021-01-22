    private static ValidationResult CheckPropertyIsValid(object obj, PropertyDescriptor propertyDescriptor)
        {
            var errors = propertyDescriptor.Attributes.OfType<ValidationAttribute>()
                .Where(x => !x.IsValid(propertyDescriptor.GetValue(obj)))
                .Select(x => new ValidationError(propertyDescriptor.Name, x.ErrorMessage));
            return new ValidationResult(errors.ToList());
        }
