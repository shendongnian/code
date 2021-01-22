		List<object> objects = new List<object>();
		// Fill the list
		foreach (object obj in object)
		{
			Type t = obj.GetType();
			PropertyInfo property = t.GetProperty("Foo");
			property.SetValue(obj, "FooFoo", null);
			Console.WriteLine(property.GetValue(obj, null));			
		}
