    using System;
    using System.IO;
    using System.Linq.Expressions;
    
    class Test    
    {    
        static Expression<Func<TOuter, TInner>> Combine<TOuter, TMiddle, TInner>
            (Expression<Func<TOuter, TMiddle>> first, 
             Expression<Func<TMiddle, TInner>> second)
        {
            var parameter = Expression.Parameter(typeof(TOuter), "x");
            var firstInvoke = Expression.Invoke(first, new[] { parameter });
            var secondInvoke = Expression.Invoke(second, new[] { firstInvoke} );
            
            return Expression.Lambda<Func<TOuter, TInner>>(secondInvoke, parameter);
        }
        
        static void Main()
        {
            Expression<Func<int, string>> first = x => (x + 1).ToString();
            Expression<Func<string, StringReader>> second = y => new StringReader(y);
    
            Expression<Func<int, StringReader>> output = Combine(first, second);
            Func<int, StringReader> compiled = output.Compile();
            var reader = compiled(10);
            Console.WriteLine(reader.ReadToEnd());
        }
    }
