    class MyConverter
    {
        public string MyToString(int x)
        {
            return x.ToString();
        }
    }
    
    static void Main()
    {
        MyConverter c = new MyConverter();
        
        ParameterExpression p = Expression.Parameter(typeof(int), "p");
        LambdaExpression intToStr = Expression.Lambda(
            Expression.Call(
                Expression.Constant(c),
                c.GetType().GetMethod("MyToString"),
                p),
            p);
        
        Func<int,string> f = (Func<int,string>) intToStr.Compile();
        
        Console.WriteLine(f(42));
        Console.ReadLine();
    }
