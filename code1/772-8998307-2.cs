    public class DoubleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is string)
            {
                double number;
                if (!Double.TryParse((value as string), out number))
                    return new ValidationResult(false, "Please enter a valid number");
            }
            return ValidationResult.ValidResult;
        }
