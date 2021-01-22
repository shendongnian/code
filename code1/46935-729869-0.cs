    static void Main( string[] args ) {
    	int A = 50, B = 30, C = 17;
    	Print( () => A );
    	Print( () => B );
    	Print( () => C );
    }
    
    static void Print<T>( System.Linq.Expressions.Expression<Func<T>> input ) {
    	System.Linq.Expressions.LambdaExpression lambda = (System.Linq.Expressions.LambdaExpression)input;
    	System.Linq.Expressions.MemberExpression member = (System.Linq.Expressions.MemberExpression)lambda.Body;
    
    	var result = input.Compile()();
    	Console.WriteLine( "{0}: {1}", member.Member.Name, result );
    }
