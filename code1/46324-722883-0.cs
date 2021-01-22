    using System;
    using System.Linq;
    using System.Linq.Expressions;
    class Program
    {
        private static readonly Random rand = new Random();
        static void Main(string[] args)
        {
            var randX = from n in Enumerable.Range(0, 100)
                        select new X { Value = rand.Next(1000) };
            ParameterExpression pe = Expression.Parameter(typeof(X), "value");
            var expression = Expression.Property(pe, "Value");
            var exp = Expression.Lambda<Func<X, int>>(expression, pe).Compile();
            foreach (var n in randX.OrderBy(exp))
                Console.WriteLine(n.Value);
        }
        public class X
        {
            public int Value { get; set; }
        }
    }
