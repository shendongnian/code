    protected IValidator FurtherValidation { private get; set; }
    
    public bool Validate()
    {
    //validate properties only found on a ship
    
        if (FurtherValidation == null)
            throw new ValidationIsRequiredException();
        if (!FurtherValidation.IsValid(this))
            // logic for invalid state
    }
