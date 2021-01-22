    object value = GetValueFromSomeAPIOrOtherMethod();
    
    if (IsValueUnacceptable(value))
    {
        // Do my stuff here, like error handling
    }
    
    ...
    
    /// <summary>
    /// Determines if the value is acceptable.
    /// </summary>
    /// <param name="value">The value to criticize.</param>
    private bool IsValueUnacceptable(object value)
    {
        return (value == null) || (string.IsNullOrEmpty(value.Prop)) || (!possibleValues.Contains(value.prop))
    }
