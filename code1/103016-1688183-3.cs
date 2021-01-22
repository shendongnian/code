    public static class ExpressionBuilders
    {
        public static Expression<Func<T,bool>> ContainsBuilder<T>( string column, string text )
        {
              ParameterExpression parameter = new Expression.Parameter( typeof(T), "t" );
        
              if (string.IsNullOrEmpty(text))
              {
                  return (Expression<Func<T,bool>>)QueryExpression.Lambda( Expression.Constant( true ), parameter );
              }
              MethodInfo contains = typeof(T).GetMethod("Contains");
              Expression textExpression = Expression.Constant(text);
              Expression containsExpression = Expression.Call(parameter,contains,textExpression);
        
              return (Expression(Func<T,bool>))QueryExpression.Lambda( containsExpression, parameter );
        }
    }
