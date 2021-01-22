	public static string GetMemberName<T, TResult>(
		this T anyObject, 
		Expression<Func<T, TResult>> expression)
	{
		return ((MemberExpression)expression.Body).Member.Name;
	}
	// call as extension method, if you have a instance
	string lengthPropertyName = "abc".GetMemberName(x => x.Length);
	// or call as a static method, by providing the type in the argument
	string lengthPropertyName = ReflectionUtility.GetMemberName(
		(string x) => x.Length);
