    public class LowerCaseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           //try to modify text
                try
                {
                    validationContext
                    .ObjectType
                    .GetProperty(validationContext.MemberName)
                    .SetValue(validationContext.ObjectInstance, value.ToString().ToLower(), null);
                }
                catch (System.Exception)
                {                                    
                }
            
            //return null to make sure this attribute never say iam invalid
            return null;
        }
    }
