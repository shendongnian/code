    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFunc());   //Prints the ToString of a Func<int, string>
            Console.WriteLine(Test(5));     //Prints "test"
            Console.WriteLine(Test2(5));    //Prints "test"
            Test2 = i => "something " + i;
            Console.WriteLine(Test2(5));    //Prints "something 5"
            //Test = i => "something " + i; //Would cause a compile error
    
        }
    
        public static string Test(int a)
        {
            return "test";
        }
    
        public static Func<int, string> Test2 = i =>
        {
            return "test";
        };
    
        public static Func<int, string> GetFunc()
        {
            return Test;
        }
    }
