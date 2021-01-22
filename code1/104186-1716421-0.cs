    class Program
    {
        class Foo
        {
            ~Foo() { Console.WriteLine("Test"); }
        }
        static void Test()
        {
            Foo foo = new Foo();
        }
        static void Main()
        {
            Test();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }
    }
