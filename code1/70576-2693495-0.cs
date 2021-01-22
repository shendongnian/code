    class TestClass
    {
        public static readonly string[] q = { "q", "w", "e" };
    }
    class Program
    {
        static void Main( string[] args )
        {
            TestClass.q[ 0 ] = "I am not const";
            Console.WriteLine( TestClass.q[ 0 ] );
        }
    }
