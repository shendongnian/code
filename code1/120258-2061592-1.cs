        static void Main(string[] args)
        {
            var bar = new Bar();
            bar.Foo = "Hello, Zap";
            Zap(() => bar.Foo);
            Console.ReadLine();
        }
        private class Bar
        {
            public String Foo { get; set; }
        }
        public static void Zap<T>(Expression<Func<T>> source)
        {
            var body = source.Body as MemberExpression;
            Bar test = Expression.Lambda<Func<Bar>>(body.Expression).Compile()();
            Console.WriteLine(test.Foo);
        } 
