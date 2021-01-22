    public void Save()
    {
        ValidationResults results = Validation.Validate(salary, "State");
    
        //Check for validity
        if (results.IsValid)
        {    
            //Now run the validation for ALL rules including State ruleset
            results.AddAllResults(Validation.Validate(salary)); 
        }    
    }
