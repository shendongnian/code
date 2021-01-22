    void Main()
    {
    	var testdata = new List<Ownr> {
    		//new Ownr{Name = "abc", Qty = 20}, // uncomment this to see it getting filtered out
    		new Ownr{Name = "abc", Qty = 2},
    		new Ownr{Name = "abcd", Qty = 11},
    		new Ownr{Name = "xyz", Qty = 40},
    		new Ownr{Name = "ok", Qty = 5},
    	};
    
    	Expression<Func<Ownr, bool>> func = Extentions.strToFunc<Ownr>("Qty", "<=", "10");
    	func = Extentions.strToFunc<Ownr>("Name", "==", "abc", func);
    
    	var result = testdata.Where(func.ExpressionToFunc()).ToList();
    
    	result.Dump();
    }
    
    public class Ownr
    {
    	public string Name { get; set; }
    	public int Qty { get; set; }
    }
    
    public static class Extentions
    {
    	public static Expression<Func<T, bool>> strToFunc<T>(string propName, string opr, string value, Expression<Func<T, bool>> expr = null)
    	{
    		Expression<Func<T, bool>> func = null;
    		try
    		{
    			var type = typeof(T);
    			var prop = type.GetProperty(propName);
    			ParameterExpression tpe = Expression.Parameter(typeof(T));
    			Expression left = Expression.Property(tpe, prop);
    			Expression right = Expression.Convert(ToExprConstant(prop, value), prop.PropertyType);
    			Expression<Func<T, bool>> innerExpr = Expression.Lambda<Func<T, bool>>(ApplyFilter(opr, left, right), tpe);
    			if (expr != null)
    				innerExpr = innerExpr.And(expr);
    			func = innerExpr;
    		}
    		catch (Exception ex)
    		{
    			ex.Dump();
    		}
    
    		return func;
    	}
    	private static Expression ToExprConstant(PropertyInfo prop, string value)
    	{
    		object val = null;
    
    		try
    		{
    			switch (prop.Name)
    			{
    				case "System.Guid":
    					val = Guid.NewGuid();
    					break;
    				default:
    					{
    						val = Convert.ChangeType(value, prop.PropertyType);
    						break;
    					}
    			}
    		}
    		catch (Exception ex)
    		{
    			ex.Dump();
    		}
    
    		return Expression.Constant(val);
    	}
    	private static BinaryExpression ApplyFilter(string opr, Expression left, Expression right)
    	{
    		BinaryExpression InnerLambda = null;
    		switch (opr)
    		{
    			case "==":
    			case "=":
    				InnerLambda = Expression.Equal(left, right);
    				break;
    			case "<":
    				InnerLambda = Expression.LessThan(left, right);
    				break;
    			case ">":
    				InnerLambda = Expression.GreaterThan(left, right);
    				break;
    			case ">=":
    				InnerLambda = Expression.GreaterThanOrEqual(left, right);
    				break;
    			case "<=":
    				InnerLambda = Expression.LessThanOrEqual(left, right);
    				break;
    			case "!=":
    				InnerLambda = Expression.NotEqual(left, right);
    				break;
    			case "&&":
    				InnerLambda = Expression.And(left, right);
    				break;
    			case "||":
    				InnerLambda = Expression.Or(left, right);
    				break;
    		}
    		return InnerLambda;
    	}
    
    	public static Expression<Func<T, TResult>> And<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
    	{
    		var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
    		return Expression.Lambda<Func<T, TResult>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
    	}
    
    	public static Func<T, TResult> ExpressionToFunc<T, TResult>(this Expression<Func<T, TResult>> expr)
    	{
    		var res = expr.Compile();
    		return res;
    	}
    }
