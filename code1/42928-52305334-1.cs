    public static string GetMemberName<T>(this Expression<T> expression)
    {
    	switch (expression.Body)
    	{
    		case MemberExpression m:
    			return m.Member.Name;
    		case UnaryExpression u when u.Operand is MemberExpression m:
    			return m.Member.Name;
    		default:
    			throw new NotImplementedException(expression.GetType().ToString());
    	}
    }
