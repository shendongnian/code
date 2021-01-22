	void Main()
	{
		var test = new Test();
		var testWithMethod = new TestWithExtensionMethod();
		Tools.IsExtensionMethodCall(() => test.Method()).Dump();
		Tools.IsExtensionMethodCall(() => testWithMethod.Method()).Dump();
	}
	
	public class Test 
	{
		public void Method() { }
	}
	
	public class TestWithExtensionMethod
	{
	}
	
	public static class Extensions
	{
		public static void Method(this TestWithExtensionMethod test) { }
	}
	
	public static class Tools
	{
	    public static MethodInfo GetCalledMethodInfo(Expression<Action> expr)
	    {
	        var methodCall = expr.Body as MethodCallExpression;
	        return methodCall.Method;
	    }
	
	    public static bool IsExtensionMethodCall(Expression<Action> expr)
	    {
	        var methodInfo = GetCalledMethodInfo(expr);
	        return methodInfo.IsStatic;
	    }
	}
