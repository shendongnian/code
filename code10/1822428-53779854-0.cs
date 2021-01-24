    public void SetProperty(object target, string property, object setTo)
    {
    	var parts = property.Split('.');
    	var prop = target.GetType().GetProperty(parts[0]);
    	if (parts.Length == 1)
    	{
    		// last property
    		prop.SetValue(target, setTo, null);
    	}
    	else
    	{
    		// Not at the end, go recursive
    		var value = prop.GetValue(target);
    		SetProperty(value, string.Join(".", parts.Skip(1)), setTo);
    	}
    }
