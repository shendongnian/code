        class Program
    {
        static void Main(string[] args)
        {
        
            var x = Expression.Parameter(typeof(object), "x");
            var y = Expression.Parameter(typeof(object), "y");
             Func<dynamic, dynamic, dynamic> f =
                 Expression.Lambda<Func<dynamic, dynamic, dynamic>>(
                     Expression.Call(typeof(Program), "Add", null, x, y),
                     new[] { x, y }
                 ).Compile();
         
           Console.WriteLine(f(5, 2));
           Console.ReadKey();
        }
        public static dynamic Add(dynamic x, dynamic y)
        {
            return x + y;
        }
    }
