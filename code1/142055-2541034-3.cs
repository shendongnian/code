    ValidationResults newResults = new ValidationResults();
    
    foreach (ValidationResult vr in validationResults)
    {
        newResults.AddResult( new ValidationResult( 
            vr.Message, vr.Target, vr.Key, "Warning", vr.Validator, vr.NestedValidationResults ) );
    }
