    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Program
    {
        static void Main()
        {
            Expression<Func<int, bool>> selector = b => true;
            ParameterExpression param = Expression.Parameter(typeof(int), "y");
            InvocationExpression member = Expression.Invoke(selector, param);
            Expression body = Expression.AndAlso(member, member);
            Expression<Func<int, bool>> predicate = Expression.Lambda<Func<int, bool>>(body, param);
            var z = predicate.Compile();
        }
    }
