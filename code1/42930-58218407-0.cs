static void Main(string[] args)
{
	var prop = GetPropertyInfo<MyDto>(_ => _.MyProperty);
	MyDto dto = new MyDto();
	dto.MyProperty = 666;
	var value = prop.GetValue(dto);
	// value == 666
}
class MyDto
{
	public int MyProperty { get; set; }
}
public static PropertyInfo GetPropertyInfo<TSource>(Expression<Func<TSource, object>> propertyLambda)
{
	Type type = typeof(TSource);
	var member = propertyLambda.Body as MemberExpression;
	if (member == null)
	{
		var unary = propertyLambda.Body as UnaryExpression;
		if (unary != null)
		{
			member = unary.Operand as MemberExpression;
		}
	}
	if (member == null)
	{
		throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.",
			propertyLambda.ToString()));
	}
	var propInfo = member.Member as PropertyInfo;
	if (propInfo == null)
	{
		throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.",
			propertyLambda.ToString()));
	}
	if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
	{
		throw new ArgumentException(string.Format("Expression '{0}' refers to a property that is not from type {1}.",
			propertyLambda.ToString(), type));
	}
	return propInfo;
}
