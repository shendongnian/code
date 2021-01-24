            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string error = "";
            var currentValue = (decimal)value;
            var comparisonValue = GetComparisonValue(_comparisonProperty, validationContext);
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = "Amount is large";
            }
            else
            {
                error = string.Format(ErrorMessage ?? "", comparisonValue);
            }
            return currentValue >= comparisonValue
                ? new ValidationResult(error)
                : ValidationResult.Success;
        }
