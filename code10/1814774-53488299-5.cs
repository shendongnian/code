    public static partial class ExpressionUtils
    {
    	public static Expression<Func<T, bool>> Match<T>(this IEnumerable<Expression<Func<T, string>>> fields, string text, bool ignoreCase)
    	{
    		Expression<Func<string, bool>> match;
    		if (ignoreCase)
    		{
    			text = text.ToLower();
    			match = input => input.ToLower().Contains(text);
    		}
    		else
    		{
    			match = input => input.Contains(text);
    		}
    		// T source =>
    		var parameter = Expression.Parameter(typeof(T), "source");
    		Expression anyMatch = null;
    		foreach (var field in fields)
    		{
    			// a.PropertyOne --> source.PropertyOne
    			// b.Child.PropertyThree --> source.Child.PropertyThree
    			var fieldAccess = field.Body.ReplaceParameter(field.Parameters[0], parameter);
    			// input --> source.PropertyOne
    			// input --> source.Child.PropertyThree
    			var fieldMatch = match.Body.ReplaceParameter(match.Parameters[0], fieldAccess);
    			// matchA || matchB
    			anyMatch = anyMatch == null ? fieldMatch : Expression.OrElse(anyMatch, fieldMatch);
    		}
    		if (anyMatch == null) anyMatch = Expression.Constant(false);
    		return Expression.Lambda<Func<T, bool>>(anyMatch, parameter);
    	}
    }
