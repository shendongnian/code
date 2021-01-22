    public static class ReflectionExtensions
    {
    	public static IList<FieldInfo> GetAllFields(this Type type, BindingFlags flags)
    	{
    		if(type == typeof(Object)) return new List<FieldInfo>();
    		
    		var list = type.BaseType.GetAllFields(flags);
    		list.AddRange(type.GetFields(flags));
    		return list;
    	}
    }
