    public class DataValidator
        {
            public class ErrorInfo
            {
                public ErrorInfo(string property, string message)
                {
                    this.Property = property;
                    this.Message = message;
                }
    
                public string Message;
                public string Property;
            }
    
            public static IEnumerable<ErrorInfo> Validate(object instance)
            {
                return from prop in instance.GetType().GetProperties()
                       from attribute in prop.GetCustomAttributes(typeof(ValidationAttribute), true).OfType<ValidationAttribute>()
                       where !attribute.IsValid(prop.GetValue(instance, null))
                       select new ErrorInfo(prop.Name, attribute.FormatErrorMessage(string.Empty));
            }
        }
