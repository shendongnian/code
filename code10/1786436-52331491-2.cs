	public static void GenerateDebug(Container c)
	{
		Type t = c.GetType();
		FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);
		foreach(FieldInfo field in fields)
		{
			var fieldName = field.Name;
			Type[] actionArgTypes = field.FieldType.GetGenericArguments();
			var dm = new DynamicMethod(fieldName, typeof(void), actionArgTypes);
			var il = dm.GetILGenerator();
			il.Emit(OpCodes.Ldstr, fieldName + " was called using ilgen");
			il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new [] {typeof(string)}));
			il.Emit(OpCodes.Ret);
			var @delegate = dm.CreateDelegate(field.FieldType);
			var action = field.GetValue(c) as Delegate;
			// Combine and set delegates
			action = Delegate.Combine(action, @delegate);
			field.SetValue(c, action);
		}
	}
