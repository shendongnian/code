    public class ValidStringAttribute  : ValidationAttribute
    {
        #region Overrides of ValidationAttribute
    
        public override void Validate(object value, PropertyInfo propertyInfo, ref IList<string> errors)
        {
            var v = propertyInfo.GetValue(value, null);
    
            if(!string.IsNullOrEmpty(v as string))
            {
                errors.Add(string.format("`{0}` cannot be null or empty",propertyInfo.Name);
            }
        }
    
        #endregion
    }
