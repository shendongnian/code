    class Program
    {
        public delegate void TestDel();
        public static void ToInvoke(TestDel testDel)
        {
            testDel();
        }
        public static void Test()
        {
            Console.WriteLine("hello world");
        }
        static void Main(string[] args)
        {
            TestDel testDel = Program.Test;
            typeof(Program).InvokeMember(
                "ToInvoke", 
                BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
                null,
                null,
                new object[] { testDel });
        }
    }
