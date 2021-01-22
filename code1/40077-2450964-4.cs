    public static string GetValueAsString(this DatabaseEnvironment environment) 
    {
        // get the field 
        var field = environment.GetType().GetField(environment.ToString());
        var customAttributes = field.GetCustomAttributes(typeof (DescriptionAttribute), false);
        if(customAttributes.Length > 0)
        {
            return (customAttributes[0] as DescriptionAttribute).Description;  
        }
        else
        {
            return environment.ToString(); 
        }
    }
