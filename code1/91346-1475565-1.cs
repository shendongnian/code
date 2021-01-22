    bool ValueHasProperty(object value)
    {
    	return (value != null) && (!string.IsNullOrEmpty(value.Prop)) && (possibleValues.Contains(value.prop));
    }
    
    void SomeMethod()
    {
    	object value = GetValueFromSomeAPIOrOtherMethod();
    	if(!ValueHasProperty(value))
    	{
    		// do stuff here
    	}
    }
