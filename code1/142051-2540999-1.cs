    public void Save(ValidationMode mode)
    {
        Validate(ValidationResultType.Errors);
        if (!mode == ValidationMode.SuppressWarnings)
        {
            Validate(ValidationResultType.Warnings);
        }
    }
    private void Validate(ValidationResultType type)
    {
        var objectToValidate;
        var ruleset = type == ValidationResultType.Errors ? "default" : "warnings";
        var validator = ValidationFactory
           .CreateValidator(objectToValidate.GetType(), ruleset);
        var results = validator.Validate();
        if (!results.IsValid)
        {
            throw new ValidationException(results, type);
        }
    }
