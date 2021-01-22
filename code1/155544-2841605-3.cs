    using System;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    
    public class Test
    {
        static void Main()
        {
            string[] names = { "Jon", "Holly", "Tom", "Robin", "Will" };
            var query = names.AsQueryable();
            query = CallOrderBy(query, "Length");
            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }
        
        private static readonly MethodInfo OrderByMethod =
            typeof(Queryable).GetMethods()
                .Where(method => method.Name == "OrderBy")
                .Where(method => method.GetParameters().Length == 2)
                .Single();
        
        public static IQueryable<TSource> CallOrderBy<TSource>
            (IQueryable<TSource> source, string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "posting");
            Expression orderByProperty = Expression.Property(parameter, propertyName);
            
            LambdaExpression lambda = Expression.Lambda(orderByProperty, new[] { parameter });
            Console.WriteLine(lambda);
            MethodInfo genericMethod = OrderByMethod.MakeGenericMethod
                (new[] { typeof(TSource), orderByProperty.Type });
            object ret = genericMethod.Invoke(null, new object[] {source, lambda});
            return (IQueryable<TSource>) ret;
        }
    }
