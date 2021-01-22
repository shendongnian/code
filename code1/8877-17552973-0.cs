    using System;
    using System.Linq.Expressions;
    
    public static class TypeHelper
    {
        public static Func<object> CreateDefaultConstructor(Type type)
        {
            NewExpression newExp = Expression.New(type);
            // Create a new lambda expression with the NewExpression as the body.
            var lambda = Expression.Lambda<Func<object>>(newExp);
            // Compile our new lambda expression.
            return lambda.Compile();
        }
    }
