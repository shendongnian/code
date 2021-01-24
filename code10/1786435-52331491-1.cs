	public static void GenerateDebug(Container c)
	{
		Type t = c.GetType();
		FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);
		foreach(FieldInfo field in fields)
		{
			var fieldName = field.Name;
			Type[] actionArgTypes = field.FieldType.GetGenericArguments();
			// Create paramter expression for each argument
			var parameters = actionArgTypes.Select(Expression.Parameter).ToArray();
			// Create method call expression with a constant argument
			var writeLineCall = Expression.Call(typeof(Console).GetMethod("WriteLine", new [] {typeof(string)}), Expression.Constant(fieldName + " was called"));
			// Create and compile lambda using the fields type
			var lambda = Expression.Lambda(field.FieldType, writeLineCall, parameters);
			var @delegate = lambda.Compile();
			var action = field.GetValue(c) as Delegate;
			// Combine and set delegates
			action = Delegate.Combine(action, @delegate);
			field.SetValue(c, action);
		}
	}
