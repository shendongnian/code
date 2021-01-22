    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    namespace Demo
    {
        using DebugLinq;
        static class Program
        {
            static void Main()
            {
                var data = System.Linq.Queryable.AsQueryable(new[] { 1, 2, 3, 4, 5 });
                data.Where(x => x % 2 == 0).Count(); 
            }
        }
    }
    namespace DebugLinq
    {
        public static class DebugQueryable
        {
            public static int Count<T>(this System.Linq.IQueryable<T> source)
            {
                return Wrap(() => System.Linq.Queryable.Count(source), "Count");
            }
            
            public static System.Linq.IQueryable<T> Where<T>(this System.Linq.IQueryable<T> source, Expression<Func<T, bool>> predicate)
            {
                return Wrap(() => System.Linq.Queryable.Where(source, predicate), "Where: " + predicate);
            }
            static TResult Wrap<TResult>(Func<TResult> func, string caption)
            {
                Debug.WriteLine(">" + caption);
                try
                {
                    TResult result = func();
                    Debug.WriteLine("<" + caption);
                    return result;
                }
                catch
                {
                    Debug.WriteLine("!" + caption);
                    throw;
                }
            }
        }
    }
