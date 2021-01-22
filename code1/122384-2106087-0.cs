    using System;
    using System.Linq;
    using System.Linq.Expressions;
    internal static class Predicate
    {
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> expression)
        {
            return expression;
        }
        public static Expression<Func<TSubject, bool>> And<TSubject>(this Expression<Func<TSubject, bool>> first,
                                                                     Expression<Func<TSubject, bool>> second)
        {
            var x = Expression.Parameter(typeof(TSubject), "x");
            var body = Expression.AndAlso(Expression.Invoke(first, x), Expression.Invoke(second, x));
            return Expression.Lambda<Func<TSubject, bool>>(body, x);
        }
        public static Expression<Func<TSubject, bool>> AndWithin<TSubject, TValue>(
            this Expression<Func<TSubject, bool>> original,
            Expression<Func<TSubject, TValue>> field)
        {
            return original.And(GetPredicateFor(field));
        }
        public static Expression<Func<TSource, bool>> GetPredicateFor<TSource, TValue>
            (Expression<Func<TSource, TValue>> selector)
        {
            var param = Expression.Parameter(typeof(TSource), "y");
            var member = Expression.Invoke(selector, param);
            Expression body =
                Expression.AndAlso(
                    Expression.GreaterThanOrEqual(member, Expression.Constant(0, typeof(TValue))),
                    Expression.LessThanOrEqual(member, Expression.Constant(1, typeof(TValue))));
            return Expression.Lambda<Func<TSource, bool>>(body, param);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var predicate = Predicate.Create<int>(a => true);
            predicate = predicate.AndWithin(b => b); // Comment out this line and it will run without error
            var z = predicate.Compile();
        }
    }
