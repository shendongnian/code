    public class TextBoxValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string s = null;
            BindingExpression be = value as BindingExpression;
            if(be != null)
            {
                object sourceObject = be.ResolvedSource;
                string sourceProperty = be.ResolvedSourcePropertyName;
                if(sourceObject != null && sourceProperty != null)
                {
                    PropertyInfo pi = sourceObject.GetType().GetProperty(sourceProperty);
                    s = pi.GetValue(sourceObject) as string;
                }
            }
            else
            {
                s = value as string;
            }
            if (string.IsNullOrEmpty(s))
                return new ValidationResult(false, "Value cannot be empty");
            return ValidationResult.ValidResult;
        }
    }
