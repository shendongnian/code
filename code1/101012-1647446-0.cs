    public static void SetField(this object o, string fieldName, object value)
    {
    	var fi = o.GetType().GetField(fieldName);
    	fi.SetValue(o, value);
    }
