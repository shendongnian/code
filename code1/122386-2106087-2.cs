    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Program
    {
        static Expression<Func<int, bool>> And(Expression<Func<int, bool>> first,
                                               Expression<Func<int, bool>> second)
        {
            var x = Expression.Parameter(typeof(int), "x");
            var body = Expression.AndAlso(Expression.Invoke(first, x), Expression.Invoke(second, x));
            return Expression.Lambda<Func<int, bool>>(body, x);
        }
    
        static Expression<Func<int, bool>> GetPredicateFor(Expression<Func<int, int>> selector)
        {
            var param = Expression.Parameter(typeof(int), "y");
            var member = Expression.Invoke(selector, param);
    
            Expression body =
                Expression.AndAlso(
                    Expression.GreaterThanOrEqual(member, Expression.Constant(0, typeof(int))),
                    Expression.LessThanOrEqual(member, Expression.Constant(1, typeof(int))));
    
            return Expression.Lambda<Func<int, bool>>(body, param);
        }
    
        static void Main()
        {
            Expression<Func<int, bool>> predicate = a => true;
            predicate = And(predicate, GetPredicateFor(b => b)); // Comment out this line and it will run without error
            var z = predicate.Compile();
        }
    }
