    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Globalization;
    
    namespace MyNamespace
    {
        public class RowValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                T_Asset item = (value as BindingGroup).Items[0] as T_Asset;
                item.ValidateModel();
    
                if (!item.HasErrors) return ValidationResult.ValidResult;
    
                return new ValidationResult(false, item.ErrorString);
            }
        }
    }
