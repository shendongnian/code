    ValidationResults newResults = new ValidationResults();
    
    foreach ( ValidationResult res in validationResults )
    {
        newResults.AddResult( new ValidationResult( res.Message, res.Target, res.Key, "Warning", res.Validator, res.NestedValidationResults ) );
    }
