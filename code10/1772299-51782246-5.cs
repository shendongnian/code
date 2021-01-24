    class Program
    {
        public const string ConstString = "mesa const";
        public static readonly string ReadonlyStatic = "mesa readonly";
        public static string ExpressionBodied => "mesa expression";
        public static string GetInitialized {get;} =  "mesa get";
        public static string GetWithBody { get { return "mesa get"; } } 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            System.Console.WriteLine("readonly:" + ReadonlyStatic);
            System.Console.WriteLine("const:" + ConstString);
            System.Console.WriteLine("expression bodied:" + ExpressionBodied);
            System.Console.WriteLine("get initialized:" + GetInitialized);
            System.Console.WriteLine("get with body:" + GetWithBody);
        }
    }
