	var type = typeof(IObjectWithProperties);
	PropertyInfo[] properties = type.GetProperties();
	foreach (PropertyInfo property in properties)
	{
		if (string.Equals(property.Name, propertyString, StringComparison.InvariantCultureIgnoreCase))
		{
			Expression<Func<IObjectWithProperties, object>> exp = u =>
			(
				 u.GetType().InvokeMember(property.Name, BindingFlags.GetProperty, null, u, null)
			);
			
			//DoSomething(exp).Dump(); // LINQPad version
            return _repo.DoSomething(exp); // your version
		}
	}
