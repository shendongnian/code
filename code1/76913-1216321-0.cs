    public static IEnumerable<string> ReturnRecs(IEnumerable items, bool returnHeader, string delimiter)
    {
    	bool haveFoundMembers = false;
    	bool haveOutputHeader = false;
    	PropertyInfo[] properties = null;
    	FieldInfo[] fields = null;
    	foreach (var item in items)
    	{
    		if (!haveFoundMembers)
    		{
    			Type type = item.GetType();
    			properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
    				.Where(pi => pi.PropertyType.IsValueType || pi.PropertyType == typeof (string)).ToArray();
    			fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
    				.Where(fi => fi.FieldType.IsValueType || fi.FieldType == typeof(string)).ToArray();
    			haveFoundMembers = true;
    		}
    		if (!haveOutputHeader)
    		{
    			yield return String.Join(delimiter, properties.Select(pi => pi.Name)
    									.Concat(fields.Select(pi => pi.Name)).ToArray());
    			haveOutputHeader = true;
    		}
    		yield return String.Join(delimiter,
    		                         properties.Select(pi => pi.GetValue(item, null).ToString())
    		                         	.Concat(fields.Select(fi => fi.GetValue(item).ToString())).ToArray());
    	}
