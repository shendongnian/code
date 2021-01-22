    using System;
    using System.Linq.Expressions;
    
    using Db4objects.Db4o.Linq.Expressions;
    
    class Test {
    
    	static void Main ()
    	{
    		Expression<Func<int, bool>> a = x => false;
    		Expression<Func<int, bool>> b = x => false;
    		Expression<Func<int, bool>> c = x => true;
    		Expression<Func<int, bool>> d = x => x == 5;
    
    		Func<Expression, Expression, bool> eq =
    			ExpressionEqualityComparer.Instance.Equals;
    
    		Console.WriteLine (eq (a, b));
    		Console.WriteLine (eq (a, c));
    		Console.WriteLine (eq (a, d));
    	}
    }
