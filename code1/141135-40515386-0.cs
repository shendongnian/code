    public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo instance)
    {
    	while (instance != null)
    	{
    		object[] attributes = instance.GetCustomAttributes(typeof(T), false);
    		if (attributes.Length > 0)
    		{
    			return attributes.Cast<T>();
    		}
    		Type ancestor = instance.DeclaringType.BaseType;
    		if (ancestor != null)
    		{
    			IEnumerable<MemberInfo> ancestormatches = ancestor.FindMembers(instance.MemberType, BindingFlags.Instance | BindingFlags.Public, 
    				(m, s) =>
    				{
    					return m.Name == (string)s;
    				}, instance.Name);
    			instance = ancestormatches.FirstOrDefault();
    		}
    		else
    		{
    			instance = null;
    		}
    	}
    	return new T[] { };
    }
