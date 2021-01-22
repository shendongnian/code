    using System.Reflection;
    
    public string GetName(Button b)
    {
    	Type t = b.GetType();
    	PropertyInfo prop = t.GetProperty("Name");
    	return prop.GetValue(b, null).ToString();
    }
