	public static IEnumerable<string> GetMemberNames<T1, T2>(Expression<Func<T1, T2>> expression)
	{
		var memberExpression = expression.Body as MemberExpression;
		if (memberExpression != null) 
		{
			return new[]{ memberExpression.Member.Name };
		}
		var memberInitExpression = expression.Body as MemberInitExpression;
		if (memberInitExpression != null)
		{
			return memberInitExpression.Bindings.Select(x => x.Member.Name);
		}
		var newExpression = expression.Body as NewExpression;
		if (newExpression != null)
		{
			return newExpression.Arguments.Select(x => (x as MemberExpression).Member.Name);
		}
		throw new ArgumentException("expression"); //use: `nameof(expression)` if C#6 or above
	}
