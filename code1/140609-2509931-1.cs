    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    class Dept
    {
        public string DeptName { get; set; }
    }
    public static class Program
    {
        static void Main()
        {
            IList<char> chars = new List<char>{'a','b'};
            Dept[] depts = new[] { new Dept { DeptName = "alpha" }, new Dept { DeptName = "beta" }, new Dept { DeptName = "omega" } };
            var count = testing(depts.AsQueryable(), dept => dept.DeptName, chars).Count();
        }
        public static IQueryable<T> testing<T>(this IQueryable<T> queryableData, Expression<Func<T,string>> pi, IEnumerable<char> chars)
        {
            var arg = Expression.Parameter(typeof(T), "x");
            var prop = Expression.Invoke(pi, arg);
            Expression body = null;
            foreach(char c in chars) {
                Expression thisFilter = Expression.Call(prop, "StartsWith", null, Expression.Constant(c.ToString()));
                body = body == null ? thisFilter : Expression.OrElse(body, thisFilter);
            }
            var lambda = Expression.Lambda<Func<T, bool>>(body ?? Expression.Constant(false), arg);
            return queryableData.Where(lambda);
        }
    }
