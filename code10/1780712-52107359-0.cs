    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var service = (IExternalService) validationContext
                             .GetService(typeof(IExternalService));
        // use service
    }
