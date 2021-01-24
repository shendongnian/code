    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public class Test
    {
        static void Main()
        {
            // Value doesn't matter... we're interested in the type inference
            IQueryable<IGrouping<string, string>> grouping = null;
            
            FakeSelect(grouping, x => x.FirstOrDefault(y => y == "Int"));
        }
        
        static void FakeSelect<TSource, TResult>(
            IQueryable<TSource> source,
            Expression<Func<TSource, TResult>> selector)
        {
            Console.WriteLine(selector);
        }
    }
