	void Main()
	{
		string propertyName = "ObjectProperty";
		ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
		MemberExpression memberExpression = Expression.Property(parameterExpression, propertyName);
		MethodCallExpression methodCall = Expression.Call(
		    typeof(Enumerable),
		    "Contains",
		    new Type[] { typeof(object) },
		    Expression.Constant(new Object[] { 1, 2, 3 }),
		    memberExpression
		);
		
		Console.WriteLine(Expression.Lambda<Func<T, bool>>(methodCall, parameterExpression).Compile()(new T()));
	}
	
	public class T
	{
		public object ObjectProperty => 2;
		public int IntProperty => 4;
	}
