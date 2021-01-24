    public Expression ToExpression<T>()
    	{
    		var expressionList = new List<Expression>();
    		
    		var parameterType = Expression.Parameter(typeof(T), "obj");
    
    		if (Ids != null && Ids.Length > 0)
    		{
    			int idValue = 0; // Filter constant
    			
    			MemberExpression idExpressionColumn = Expression.Property(parameterType, "Id");
    
    			ConstantExpression idConstantExpression = Expression.Constant(idValue, typeof(int));
    			
    			MethodInfo filtersMethodInfo = typeof (HashsetExtensions).GetMethod("Contains", new[] {typeof (HashSet<int>), typeof (int)});
    			
    			var methodCallExpression = Expression.Call(null, filtersMethodInfo, idExpressionColumn, idConstantExpression);
    			
    			expressionList.Add(methodCallExpression);
    		}
    		if (!string.IsNullOrEmpty(Name))
    		{
    			string nameValue = ""; // Filter constant
    
    			MemberExpression nameExpressionColumn = Expression.Property(parameterType, "Name");
    
    			ConstantExpression nameConstantExpressionColumn = Expression.Constant(nameValue, typeof(string));
    
    			MethodInfo filtersMethodInfo = typeof(StringExtensions).GetMethod("Contains", new[] { typeof(string), typeof(string) });
    
    			var methodCallExpression = Expression.Call(null, filtersMethodInfo, nameExpressionColumn, nameConstantExpressionColumn);
    
    			expressionList.Add(methodCallExpression);
    		}
    		
    		// Binary Expression (Simple Comparison)
    		
    		bool showAllValue = true;
    
    		MemberExpression showAllExpressionColumn = Expression.Property(parameterType, "ShowAll");
    
    		ConstantExpression constantExpressionColumn = Expression.Constant(showAllValue, typeof(bool));
    		
    		expressionList.Add(Expression.Equal(showAllExpressionColumn,constantExpressionColumn));
    
    		var resultExpression = expressionList.Skip(1).Aggregate(expressionList.First(),(expr1,expr2) => Expression.And(expr1,expr2))
    
    		// how to combine list of expressions into composite expression???
    		return Expression.Lambda<Func<T, bool>>(resultExpression, parameterType);
    	}
    }
    
    public static class StringExtensions
    {
    	public static bool Contains(this string source, string subString)
    	{
    		return source?.IndexOf(subString, StringComparison.OrdinalIgnoreCase) >= 0;
    	}
    }
    
    public static class HashsetExtensions
    {
    	public static bool Contains(this HashSet<string> source, string subString)
    	{
    		return source.Contains(subString,StringComparer.OrdinalIgnoreCase);
    	}
    
    	public static bool Contains(this HashSet<int> source, int value)
    	{
    		return source.Contains(value);
    	}
    }
