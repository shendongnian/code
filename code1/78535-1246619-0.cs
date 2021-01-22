    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    static class Extensions
    {
        public static List<T> Filter<T>
            (this List<T> source, string columnName, 
             string compValue)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression property = Expression.Property(parameter, columnName);
            Expression constant = Expression.Constant(compValue);
            Expression equality = Expression.Equal(property, constant);
            Expression<Func<T, bool>> predicate =
                Expression.Lambda<Func<T, bool>>(equality, parameter);
            
            Func<T, bool> compiled = predicate.Compile();
            return source.Where(compiled).ToList();
        }
    }
    
    class Test
    {
        static void Main()
        {
            var people = new[] {
                new { FirstName = "John", LastName = "Smith" },
                new { FirstName = "John", LastName = "Noakes" },
                new { FirstName = "Linda", LastName = "Smith" },
                new { FirstName = "Richard", LastName = "Smith" },
                new { FirstName = "Richard", LastName = "Littlejohn" },
            }.ToList();
            
            foreach (var person in people.Filter("LastName", "Smith"))
            {
                Console.WriteLine(person);
            }
        }
    }
