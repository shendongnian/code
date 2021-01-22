    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Linq.Expressions;
    public static class EnumerableHelper
    {
        static MethodInfo orderBy = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(x => x.Name == "OrderBy" && x.GetParameters().Length == 2).First();
        public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, string propertyName)
        {
            var pi = typeof(TSource).GetProperty(propertyName, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            var selectorParam = Expression.Parameter(typeof(TSource), "keySelector");
            var sourceParam = Expression.Parameter(typeof(IEnumerable<TSource>), "source");
            return 
                Expression.Lambda<Func<IEnumerable<TSource>, IOrderedEnumerable<TSource>>>
                (
                    Expression.Call
                    (
                        orderBy.MakeGenericMethod(typeof(TSource), pi.PropertyType), 
                        sourceParam, 
                        Expression.Lambda
                        (
                            typeof(Func<,>).MakeGenericType(typeof(TSource), pi.PropertyType), 
                            Expression.Property(selectorParam, pi), 
                            selectorParam
                        )
                    ), 
                    sourceParam
                )
                .Compile()(source);
        }
        public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, string propertyName, bool ascending)
        {
            return ascending ? source.OrderBy(propertyName) : source.OrderBy(propertyName).Reverse();
        }
    }
