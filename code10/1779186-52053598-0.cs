    public class TextLengthValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            var str = (value as BindingGroup).Items[0] as string;
            if (str.Length > 33)
            {
                return new ValidationResult(false,
                    "Text must be shorter than 33 chars");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
