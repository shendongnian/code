	if(Value is IEnumerable && !(Value is string))
	{
		if(Operator != Operator.Eq)
		{
			throw new ArgumentException("Operator must be set to Eq for Enumerable types");
		}
		List<string> @params = new List<string>();
		foreach(var value in (IEnumerable)Value)
		{
			string valueParameterName = parameters.SetParameterName(this.PropertyName, value, sqlGenerator.Configuration.Dialect.ParameterPrefix);
			@params.Add(valueParameterName);
		}
		string paramStrings = @params.Aggregate(new StringBuilder(), (sb, s) => sb.Append((sb.Length != 0 ? ", " : string.Empty) + s), sb => sb.ToString());
		return string.Format("({0} {1}IN ({2}))", columnName, Not ? "NOT " : string.Empty, paramStrings);
	}
