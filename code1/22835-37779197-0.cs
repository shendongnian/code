    static void Main(string[] args)
        {
            Expression<Func<int, int, int>> exFunc = (a, b) => a + b;
            var lambda = exFunc as LambdaExpression;
            Delegate del = exFunc.Compile();
            Console.WriteLine(del.DynamicInvoke(2, 2));
        }
