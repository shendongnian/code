        static void Main(string[] args)
        {
            var bar = new Bar();
            bar.Foo = "Hello, Zap";
            Zap(() => bar.Foo);
        }
        private class Bar
        {
            public String Foo { get; set; }    
        }
        public static void Zap<T>(Expression<Func<T>> source)
        {
            var param = (((source.Body as MemberExpression).Expression as MemberExpression).Expression as ConstantExpression).Value;
            var type = param.GetType();
            // Note that the C# compiler creates the field of the closure class 
            // with the name of local variable that was captured in Main()
            var field = type.GetField("bar");
            var bar = field.GetValue(param) as Bar;
            Debug.Assert(bar != null);
            Console.WriteLine(bar.Foo);
        }
