    using System;
    using System.Linq.Expressions;
    
    class Example
    {
    	static void Main()
    	{
    		Expression<Func<Boolean>> expression 
                    = () => "MyValue".StartsWith("MyV");
    		Func<Boolean> func = expression.Compile();
    		Boolean result = func();
    	}
    }
