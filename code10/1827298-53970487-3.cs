    class Program
    {
        static LambdaExpression TestMethod(Expression<Func<int, int>> expression)
        {
            return expression;
        }
    
        static void Main(string[] args)
        {
            var expr = TestMethod(i => i + 1);
    
            var result = Expression.Lambda<Func<int, int>>(expr.Body, expr.Parameters).Compile().Invoke(1);
    
            Console.WriteLine(result);
        }
    }
