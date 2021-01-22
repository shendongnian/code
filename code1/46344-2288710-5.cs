    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class IQueryableHelper
    {
        static MethodInfo orderBy = typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(x => x.Name == "OrderBy" && x.GetParameters().Length == 2).First();
        static MethodInfo orderByDescending = typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(x => x.Name == "OrderByDescending" && x.GetParameters().Length == 2).First();
        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, params string[] sortDescriptors)
        {
            return sortDescriptors.Length > 0 ? source.OrderBy(sortDescriptors, 0) : source;
        }
        static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string[] sortDescriptors, int index)
        {
            if (index < sortDescriptors.Length - 1) source = source.OrderBy(sortDescriptors, index + 1);
            string[] splitted = sortDescriptors[index].Split(' ');
            var pi = typeof(TSource).GetProperty(splitted[0], BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.IgnoreCase);
            var selectorParam = Expression.Parameter(typeof(TSource), "keySelector");
            return source.Provider.CreateQuery<TSource>(Expression.Call((splitted.Length > 1 && string.Compare(splitted[1], "desc", StringComparison.Ordinal) == 0 ? orderByDescending : orderBy).MakeGenericMethod(typeof(TSource), pi.PropertyType), source.Expression, Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(TSource), pi.PropertyType), Expression.Property(selectorParam, pi), selectorParam)));
        }
    }
