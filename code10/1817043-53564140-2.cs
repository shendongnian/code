	static void OverwriteWithReflection(MyClass1 o1, MyClass2 o2)
	{
		var targetType = o2.GetType();
		
		foreach (var fromProperty in o1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
		{
			if (!fromProperty.CanRead) continue; //Source property is write-only
			var toProperty = targetType.GetProperty(fromProperty.Name, BindingFlags.Instance | BindingFlags.Public);
			if (toProperty == null) continue; //No matching property
			if (!toProperty.CanWrite) continue; //Target is read only
			if (toProperty.PropertyType != fromProperty.PropertyType) continue; //Properties aren't the same type
			toProperty.SetValue(o2, fromProperty.GetValue(o1, null));
		}
	}
