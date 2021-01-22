    using System.ComponentModel.DataAnnotations;
    using Resources;
    namespace Web.Extensions.ValidationAttributes
    {
        public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
        {
            public RequiredAttribute()
            {
              ErrorMessageResourceType = typeof (Errors);
              ErrorMessageResourceName = "Required";
            }
    
            protected override ValidationResult IsValid(object value, ValidationContext  validationContext)
            {
                return base.IsValid(value, validationContext.LocalizeDisplayName());
            }
        }
    }
