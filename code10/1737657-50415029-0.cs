    class Program
    {
        static void Main(string[] args)
        {
            Type1 something1 = new Type1();
            Type2 something2 = new Type2();
            something1.runTest();
            something2.runTest();
            Console.ReadKey();
        }
        public class Type1
        {
            public void runTest()
            {
                Testing.edit(this);
            }
        }
        public class Type2
        {
            public void runTest()
            {
                Testing.edit(this);
            }
        }
        public static class Testing
        {
            public static void edit(object obj)
            {
                // This is where you test the calling class to make sure
                // it is allowed to edit.
                Console.WriteLine(obj.GetType().ToString());
            }
        }
    }
