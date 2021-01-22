    public abstract class DataErrorInfo : IDataErrorInfo
    {
        string IDataErrorInfo.Error
        {
            get { return string.Empty; }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                var prop = this.GetType().GetProperty(columnName);
                return this.GetErrorInfo(prop); 
            }
        }
        private string GetErrorInfo(PropertyInfo prop)
        {
            var validator = this.GetPropertyValidator(prop);
            if (validator != null)
            {
               var results = validator.Validate(this);
               if (!results.IsValid)
               {
                  return string.Join(" ",
                      results.Select(r => r.Message).ToArray());
               }
            }
            return string.Empty;
        }
        private Validator GetPropertyValidator(PropertyInfo prop)
        {
            string ruleset = string.Empty;
            var source = ValidationSpecificationSource.All;
            var builder = new ReflectionMemberValueAccessBuilder();
            return PropertyValidationFactory.GetPropertyValidator(
                this.GetType(), prop, ruleset, source, builder);
        }
    }
