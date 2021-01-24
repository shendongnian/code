    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int>> expr = i => i + 1;
    
            var result = expr.Compile().Invoke(1);
    
            Console.WriteLine(result);
        }
    }
