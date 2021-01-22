    public class SecurityExpressionBuilder : ISecurityExpression
    {
    	private readonly List<SecurityExpression> _expressions;
    
    	public SecurityExpressionBuilder()
    	{
    		_expressions = new List<SecurityExpression>();
    	}
    
    	public ISecurityExpression UserWorksForCompany(string company)
    	{
    		var expression = new CompanySecurityExpression(company);
    		_expressions.Add(expression);
    		return this;
    	}
    
    	public ISecurityExpression IsTrue(bool expr)
    	{
    		var expression = new BooleanSecurityExpression(expr);
    		_expressions.Add(expression);
    		return this;
    	}
    
    	public bool Eval()
    	{
    		return _expressions.All(e => e.Eval());
    	}
    
    	public bool EvalAny()
    	{
    		return _expressions.Any(e => e.Eval());
    	}
    }
