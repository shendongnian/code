    // I _think_ the original fields are used internally, so I
    // couldn't dispense with them entirely.
    public string NormalisedEmail
    {
    	get => NormalizedEmail;
    	set => NormalizedEmail = value.ToLowerInvariant();
    }
    public string NormalisedUserName
    {
    	get => NormalizedUserName;
    	set => NormalizedUserName = value.ToLowerInvariant();
    }
