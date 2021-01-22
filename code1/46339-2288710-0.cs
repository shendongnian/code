    public static class EnumerableHelper
    {
        static MethodInfo orderBy = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(x => x.Name == "OrderBy" && x.GetParameters().Length == 2).First();
        public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, string propertyName)
        {
            return source.OrderBy(propertyName, false);
        }
        public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, string propertyName, bool descending)
        {
            var pi = typeof(TSource).GetProperty(propertyName, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            var selectorParam = Expression.Parameter(typeof(TSource), "selector");
            var listParam = Expression.Parameter(typeof(IEnumerable<TSource>), "list");
            var result = ((Expression<Func<IEnumerable<TSource>, IOrderedEnumerable<TSource>>>)Expression.Lambda(Expression.Call(orderBy.MakeGenericMethod(typeof(TSource), pi.PropertyType), listParam, Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(TSource), pi.PropertyType), Expression.Property(selectorParam, pi), selectorParam)), listParam)).Compile()(source);
            return descending ? result.Reverse() : result;
        }
    }
