    private static object CallConstructor(Assembly asm, string constructorTestClassName, string testClassName)
	{
		Type paramType = asm.GetType(testClassName);
		var paramsArray = Array.CreateInstance(paramType, 1);
		paramsArray.SetValue(Activator.CreateInstance(paramType), 0);
		var parameters = new object[] {paramsArray};
		return asm.CreateInstance(constructorTestClassName, true, 
                      BindingFlags.CreateInstance, null, 
                      parameters, null, null);
	}
