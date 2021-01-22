    static string PrettyTypeName(Type t)
    {
	    if (t.IsArray)
	    {
		    return PrettyTypeName(t.GetElementType()) + "[]";
	    }
        if (t.IsGenericType)
        {
            return string.Format(
                "{0}<{1}>",
                t.Name.Substring(0, t.Name.LastIndexOf("`", StringComparison.InvariantCulture)),
                string.Join(", ", t.GetGenericArguments().Select(PrettyTypeName)));
        }
    
        return t.Name;
    }
