    public class A 
    {
    	public int Value { get; set; }
    }
	public static S DoStuff<T, S>(T some, Expression<Func<T, S>> propertySelector)
	{
		var propertyType = ((MemberExpression)selector.Body).Member;
		var somePropertyValue = propertySelector.Compile()(some);
		
		return somePropertyValue;
	}
