    using System;
    using System.Linq.Expressions;
    
    class Test
    {
        // This is the method you want, I think
        static Expression<Func<TInput,object>> AddBox<TInput, TOutput>
            (Expression<Func<TInput, TOutput>> expression)
        {
            // Add the boxing operation, but get a weakly typed expression
            Expression converted = Expression.Convert
                 (expression.Body, typeof(object));
            // Use Expression.Lambda to get back to strong typing
            return Expression.Lambda<Func<TInput,object>>
                 (converted, expression.Parameters);
        }
        // Just a simple demo
        static void Main()
        {
            Expression<Func<string, DateTime>> x = text => DateTime.Now;
            var y = AddBox(x);        
            object dt = y.Compile()("hi");
            Console.WriteLine(dt);
        }        
    }
