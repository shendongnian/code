    using System;  
    using System.Linq;  
    using System.Linq.Expressions;  
      
    public static class Extensions  
    {  
        public static IQueryable<T> WhereLike<T>(this IQueryable<T> source, string propertyName, string pattern)  
        {  
            if (null == source) throw new ArgumentNullException("source");  
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("propertyName");  
              
            var a = Expression.Parameter(typeof(T), "a");  
            var prop = Expression.Property(a, propertyName);  
            var body = Expression.Call(typeof(SqlMethods), "Like", null, prop, Expression.Constant(pattern));  
            var fn = Expression.Lambda<Func<T, bool>>(body, a);  
              
            return source.Where(fn);  
        }  
    }  
    ...  
    .WhereLike("Description", "%a%b%c%"));  
