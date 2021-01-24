    class Program
    {
        static Expression TestMethod(Expression<Func<int, int>> expression)
        {
            return expression;
        }
    
        static void Main(string[] args)
        {
            var expr = TestMethod(i => i + 1);
    
            var result = ((Expression<Func<int, int>>)expr).Compile().Invoke(1);
    
            Console.WriteLine(result);
        }
    }
