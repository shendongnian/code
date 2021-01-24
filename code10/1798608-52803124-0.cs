	internal class DemoVisitor : ExpressionVisitor
	{
	    private Type type;
	    private MemberInfo _member;
	
	    public static (Type, MemberInfo) GetMemberInfo(LambdaExpression expression)
	    {
	        var visitor = new DemoVisitor();
	        visitor.Visit(expression);
	
	        return (visitor.type, visitor._member);
	    }
	
	    protected override Expression VisitMember(MemberExpression node)
	    {
	        if (_member == null)
	        {
	          _member = node.Member;
	          type = node.Expression.Type;
	        }
	
	        return base.VisitMember(node);
	    }
	}
