    object o = PropertyGrid.SelectedObject;
    Type t = o.GetType();  // We will work on type "t"
    List<MemberInfo> members = new List<MemberInfo>();
    members.AddRange(t.GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);  // Get the public instance properties list
    foreach (MemberInfo member in members)
    {
    	Type type = null;
    	object value = null;
    	PropertyInfo pi = (member as PropertyInfo);
    	type = pi.PropertyType;
    	if (type.IsSubclassOf(typeof(CollectionBase)))
    		continue;  // Sorry
    	if (pi.GetCustomAttributes(typeof(NotSerializedAttribute), true).GetLength(0) > 0)
    		continue;
    	if (!pi.CanRead || !pi.CanWrite)
    		continue;
    	value = pi.GetValue(o, null);
    	// TODO Print out, or save the "value"
    }
