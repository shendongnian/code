    var parameters = methodinfo.GetParameters();
	foreach (var parameter in parameters)
	{
		var HasValue = "";
		Type ParameterType = (parameter.IsOut || parameter.ParameterType.IsByRef) ? parameter.ParameterType.GetElementType() : parameter.ParameterType;
		if (ParameterType.GetProperties().Count() == 2 && ParameterType.GetProperties()[0].Name.Equals("HasValue"))
		{
			HasValue = "?";
			ParameterType = ParameterType.GetProperties()[1].PropertyType;
		} 
		StringBuilder sb = new StringBuilder();
		using (StringWriter sw = new StringWriter(sb))
		{
			var expr = new CodeTypeReferenceExpression(ParameterType);
			var prov = new CSharpCodeProvider();
			prov.GenerateCodeFromExpression(expr, sw, new CodeGeneratorOptions());
		}
		var result = string.Concat(sb.ToString(), HasValue, " ", parameter.Name);
		Console.WriteLine(result);
	}
