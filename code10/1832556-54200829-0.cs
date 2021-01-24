    public class CycleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup group = (BindingGroup)value;
            StringBuilder error = null;
            foreach (var item in group.Items)
            {
                IDataErrorInfo info = item as IDataErrorInfo;
                if (info != null)
                {
                    if (!string.IsNullOrEmpty(info.Error))
                    {
                        if (error == null)
                        {
                            error = new StringBuilder();
                        }
                        error.Append((error.Length != 0 ? ", " : "") + info.Error);
                    }
                }
            }
            if (error != null)
                return new ValidationResult(false, error.ToString());
            else
                return new ValidationResult(true, "");
        }
    }
