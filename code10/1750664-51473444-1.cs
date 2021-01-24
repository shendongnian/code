    public class ExpressionConvertor: ExpressionVisitor
    {
    	private ParameterExpression ad2Parameter;
    	public ExpressionConvertor(ParameterExpression ad2Parameter)
    	{
    		this.ad2Parameter = ad2Parameter;
    	}
    	
    	public override Expression Visit(Expression node)
    	{
    		if(node is LambdaExpression node2)
    		{
    			var exp = base.Visit(node2.Body);
    			return Expression.Lambda(exp, ad2Parameter);
    		}
    		return base.Visit(node);
    	}
    
    	protected override Expression VisitMember(MemberExpression node)
    	{		
    		if(node.Expression is ParameterExpression)
    			return Expression.PropertyOrField(ad2Parameter, node.Member.Name);
    			
    		return base.VisitMember(node);
    	}
    }
