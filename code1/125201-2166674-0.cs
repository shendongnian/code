    namespace Sample
    {
        using System;
        using System.Collections.Generic;
        using System.Linq.Expressions;
        internal class ExpressionSample
        {
            private static Expression<TDelegate> Negate<TDelegate>(Expression<TDelegate> expression)
            {
                return Expression.Lambda<TDelegate>(Expression.Not(expression.Body), expression.Parameters);
            }
            private static void Main()
            {
                // Match any string of length 2 or more characters
                Expression<Predicate<string>> expression = (s) => s.Length > 1;
                // Logical negation, i.e. match string of length 1 or fewer characters
                Expression<Predicate<string>> negatedExpression = ExpressionSample.Negate(expression);
                // Compile expressions to predicates
                Predicate<string> predicate = expression.Compile();
                Predicate<string> negativePredicate = negatedExpression.Compile();
                List<string> list1 = new List<string> { string.Empty, "an item", "x", "another item" };
                List<string> list2 = new List<string> { "yet another item", "still another item", "y", string.Empty };
                list2.RemoveAll(negativePredicate);
                list2.AddRange(list1.FindAll(predicate));
                list2.ForEach((s) => Console.WriteLine(s));
            }
        }
    }
