    public static class ObjectHelper
    {
        public static void ToConsole<T>(this IEnumerable<T> enumerable, Expression<Func<T,object>> expr)
            where T:class
        {
            var fn = expr.Compile();
            var result = enumerable.Select(s => fn(s));
            Console.WriteLine($"My data selected as {PrettyPrintExpression(expr)}");
            foreach(var element in result)
            {
                Console.WriteLine(/*  etc.  */);
            }
        }
        private static string PrettyPrintExpression(Expression<Func<T,object>> expr)
        {
            // Walk the expression tree to print as desired
        }
    }
