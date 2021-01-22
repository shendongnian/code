    // from database
    string parameterTypeName = "System.AttributeTargets";
    string paramaterValueString = "Assembly";
    
    
    
    object parameterValue;
    Type parameterType = Type.GetType(parameterTypeName);
    
    if(parameterType.IsEnum)
    {
    	parameterValue = Enum.Parse(parameterType, paramaterValueString);
    }
    else
    {
    	// do other things
    }
    
    
    // use your parameter
