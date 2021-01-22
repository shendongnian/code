    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using ConsoleApplication1; // my data-context's namespace
    static class Program
    {
        public static void Main()
        {
            using (var context = new TestDataContext())
            {
                context.Log = Console.Out; // to check it has worked
                IQueryable<Order> lhs = context.Orders;
                IQueryable<Order_Detail> rhs = context.Order_Details;
                // how ever many predicates etc here
                rhs = addBeforeJoin(rhs, 4);
    
                var result = lhs.Join(rhs,
                       a => a.OrderID,
                       b => b.OrderID,
                      (a, b) => new { A = a, B = b }
                );
                // or add after
                result = result.Where(row => row.B, addAfterJoin(100));
                Console.WriteLine(result.Count());
            }
        }
    
        private static IQueryable<Order_Detail> addBeforeJoin(IQueryable<Order_Detail> query, int value)
        {
            return query.Where(r => r.Quantity >= value);
        }
        private static Expression<Func<Order_Detail, bool>> addAfterJoin(int value)
        {
            return r => r.Quantity <= value;
        }
        private static IQueryable<TSource> Where<TSource, TProjection>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TProjection>> selector,
            Expression<Func<TProjection, bool>> predicate)
        {
            return source.Where(
                Expression.Lambda<Func<TSource, bool>>(
                Expression.Invoke(predicate, selector.Body),
                selector.Parameters));
        }
    
    }
