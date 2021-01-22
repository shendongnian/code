    static class Squarer<T>
    {
        private static readonly Func<T, T> _square;
        static Squarer()
        {
            ParameterExpression x = Expression.Parameter(typeof(T), "x");
            _square = Expression.Lambda<Func<T, T>>(
                Expression.Multiply(x, x),
                x).Compile();
        }
        
        public static T Square(T value)
        {
            return _square.Invoke(value);
        }
    }
    
    Console.WriteLine(Squarer<double>.Square(1234.5678));
    Console.WriteLine(Squarer<decimal>.Square(1234.5678m));
    Console.WriteLine(Squarer<int>.Square(1234));
