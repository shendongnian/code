    class Program
    {
        public static void Main(string[] args)
        {
            var theExpression = CreateExpression<Test>("Name");
            var theExpressionStrongType = theExpression as Expression<Func<Test, string>>;
            //now you could use theExpressionStrongType
            //or do this and go wild. :)
            dynamic d = theExpression;
            Console.ReadKey();
        }
    }
    class Test
    {
        public string Name { get; set; }
    }
