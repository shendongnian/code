    public static bool HasConversionOperator( Type from, Type to )
    		{
    			Func<Expression, UnaryExpression> bodyFunction = body => Expression.Convert( body, to );
    			ParameterExpression inp = Expression.Parameter( from, "inp" );
    			try
    			{
    				// If this succeeds then we can cast 'from' type to 'to' type using implicit coercion
    				Expression.Lambda( bodyFunction( inp ), inp ).Compile();
    				return true;
    			}
    			catch( InvalidOperationException )
    			{
    				return false;
    			}
    		}
