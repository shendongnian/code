    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    public class Test
    {
        static void Main()
        {
            IQueryable<string> strings = (new[] { "Jon", "Tom", "Holly", 
                 "Robin", "William" }).AsQueryable();
            
            
            Expression<Func<string, bool>> firstPredicate = p => p.Contains("ll");
            Expression<Func<string, bool>> secondPredicate = p => p.Length == 3;
            Expression combined = Expression.OrElse(firstPredicate.Body,
                                                    secondPredicate.Body);
            
            ParameterExpression param = Expression.Parameter(typeof(string), "p");
            ParameterReplacer replacer = new ParameterReplacer(param);
            combined = replacer.Visit(combined);
            
            var lambda = Expression.Lambda<Func<string, bool>>(combined, param);
            
            var query = strings.Where(lambda);
            
            foreach (string x in query)
            {
                Console.WriteLine(x);
            }
        }
    
        // Helper class to replace all parameters with the specified one
        class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression parameter;
            
            internal ParameterReplacer(ParameterExpression parameter)
            {
                this.parameter = parameter;
            }
            
            protected override Expression VisitParameter
                (ParameterExpression node)
            {
                return parameter;
            }
        }
    }
