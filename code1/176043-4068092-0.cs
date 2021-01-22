    public abstract class DataErrorInfo : IDataErrorInfo
    {
        string IDataErrorInfo.Error { get { return string.Empty; } }
        string IDataErrorInfo.this[string columnName]
        {
            get { return this.GetErrorInfo(this.GetType().GetProperty(columnName)); }
        }
        private string GetErrorInfo(PropertyInfo property)
        {
            var validator = this.GetPropertyValidator(property);
            if (validator != null)
            {
               var results = validator.Validate(this);
               if (!results.IsValid)
                  return string.Join(" ", results.Select(r => r.Message).ToArray());
            }
            return string.Empty;
        }
        private Validator GetPropertyValidator(PropertyInfo property)
        {
            string ruleset = string.Empty;
            var source = ValidationSpecificationSource.All;
            var builder = new ReflectionMemberValueAccessBuilder();
            return PropertyValidationFactory.GetPropertyValidator(
                this.GetType(), property, ruleset, source, builder);
        }
    }
