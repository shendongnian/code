    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace LinqResearch
    {
        public class Program
        {
            [STAThread]
            static void Main()
            {
                string columnToGroupBy = "Size";
    
                // generate the dynamic Expression<Func<Product, string>>
                ParameterExpression p = Expression.Parameter(typeof(Product), "p");
    
                var selector = Expression.Lambda<Func<Product, string>>(
                    Expression.Property(p, columnToGroupBy),
                    p
                );
    
                using (LinqDataContext dataContext = new LinqDataContext())
                {
                    /* using "selector" caluclated above which is automatically 
                    compiled when the query runs */
                    var results = dataContext
                        .Products
                        .GroupBy(selector)
                        .Select((group) => new { 
                            Key = group.Key, 
                            Count = group.Count()
                        });
    
                    foreach(var result in results)
                        Console.WriteLine("{0}: {1}", result.Key, result.Count);
                }
    
                Console.ReadKey();
            }
        }
    }
