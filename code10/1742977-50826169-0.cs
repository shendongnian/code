	static TExpr ReplaceExpressions<TExpr>(TExpr expression,
	                                              Expression orig,
	                                              Expression replacement)
	where TExpr : Expression 
	{
	    var replacer = new ExpressionReplacer(orig, replacement);
	    return replacer.VisitAndConvert(expression, "ReplaceExpressions");
	}
	
	private class ExpressionReplacer : ExpressionVisitor
	{
	    private readonly Expression From;
	    private readonly Expression To;
	
	    public ExpressionReplacer(Expression from, Expression to) {
	        From = from;
	        To = to;
	    }
	
	    public override Expression Visit(Expression node) {
	        if (node == From) {
	            return To;
	        }
	        return base.Visit(node);
	    }
	}
