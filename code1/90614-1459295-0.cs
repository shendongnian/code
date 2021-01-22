    public void SomeFunction(object someParameter)
    {
    	if (someParameter == null) throw new ArgumentNullException("someParameter", "Value cannot be null");
    	
    	// Use the parameter here for stuff
    	SomeOtherFunction(someParameter, Whichway.Up);
    }
