    public static JsonResult ValidateProperty(object propertyValue, string propertyName, object sourceObject)
    {
        ValidationContext context = new ValidationContext(sourceObject)
        {
                MemberName = propertyName
        };
    
        List<ValidationResult> results = new List<ValidationResult>();
        bool valid = Validator.TryValidateProperty(propertyValue, context, results);
    
        // ...
