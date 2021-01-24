    public class Test
    {
    	public int Value {get;set;}
    }
    
    public void ChangeStat<T, TValue>(T target, Expression<Func<T, TValue>> memberLamda, TValue value)
    {
        if (memberLamda.Body is MemberExpression memberExpr && memberExpr != null )
        {
        	if (memberExpr.Member is PropertyInfo property && property != null)
            {
            	property.SetValue(target, value, null);
            }
        }
    }
