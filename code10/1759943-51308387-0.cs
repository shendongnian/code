	public static void GetGenericVariables()
	{
        //Declaring two variables here that use Foo<>
		var inttype = new Foo<int>();
		var stringType = new Foo<string>();
		var methodInfo = typeof(ClassContainingMethod).GetMethod("GetGenericVariables");
		var variables = methodInfo.GetMethodBody().LocalVariables;
		foreach (var variable in variables)
		{
			if (variable.LocalType.IsGenericType && variable.LocalType.GetGenericTypeDefinition() == typeof(Foo<>))
			{
				Console.WriteLine(variable.LocalType.GenericTypeArguments[0].FullName);
			}
		}
	}
