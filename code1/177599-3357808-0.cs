    public static class SecurityGuard
    {
    	private const string ExceptionText = "Permission denied.";
    
    	public static bool Require(Action<ISecurityExpression> action)
    	{
    		var expression = new SecurityExpressionBuilder();
    		action.Invoke(expression);
    		return expression.Eval();
    	}
    
    	public static bool RequireOne(Action<ISecurityExpression> action)
    	{
    		var expression = new SecurityExpressionBuilder();
    		action.Invoke(expression);
    		return expression.EvalAny();
    	}
    
    	public static void ExcpetionIf(Action<ISecurityExpression> action)
    	{
    		var expression = new SecurityExpressionBuilder();
    		action.Invoke(expression);
    		if(expression.Eval())
    		{
    			throw new SecurityException(ExceptionText);
    		}
    	}
    }
    public interface ISecurityExpression
    {
    	ISecurityExpression UserWorksForCompany(string company);
    	ISecurityExpression IsTrue(bool expression);
    }
