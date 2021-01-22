    public class EqualsAttribute : ValidationAttribute
    {
     private readonly String _To;
     public EqualsAttribute(String to)
     {
      if (String.IsNullOrEmpty(to))
      {
       throw new ArgumentNullException("to");
      }
      if (String.IsNullOrEmpty(key))
      {
       throw new ArgumentNullException("key");
      }
      _To = to;
     }
    
    
     protected override Boolean IsValid(Object value, ValidationContext validationContext, out ValidationResult validationResult)
     {
      validationResult = null;
      var isValid = IsValid(value, validationContext);
      if (!isValid)
      {
       validationResult = new ValidationResult(
        FormatErrorMessage(validationContext.DisplayName),
        new [] { validationContext.MemberName });
      }
      return isValid;
     }
    
     private Boolean IsValid(Object value, ValidationContext validationContext)
     {
      var propertyInfo = validationContext.ObjectType.GetProperty(_To);
      if (propertyInfo == null)
      {
       return false;
      }
      var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
      return Equals(value, propertyValue);
     }
    
     public override Boolean IsValid(Object value)
     {
      throw new NotSupportedException();
     }
    }
