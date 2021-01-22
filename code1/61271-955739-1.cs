    class Program
    {
        const int ITERATION_COUNT = 100000000;
        private static UInt64 stringCount = 0;
        private static UInt64 objectCount = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Over {0} iterations ", ITERATION_COUNT);
            string s = "Hello";
            object o = new Int32();
            RunTest("AS   : Failure  {0}", TestAs, o);
            RunTest("Cast : Failure  {0}", TestIs_And_Cast, o);
            RunTest("AS   : Success  {0}", TestAs, s);
            RunTest("Cast : Success  {0}", TestIs_And_Cast, s);
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }
        private static void RunTest(string testDescription, Action<object> testToRun, object arg)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < ITERATION_COUNT; i++)
                testToRun(arg);
            sw.Stop();
            Console.WriteLine(testDescription, sw.Elapsed);
        }
        static void TestAs(object obj)
        {
            string s = obj as string;
            if (s != null)
                stringCount++;
            else
                objectCount++;
        }
        static void TestIs_And_Cast(object obj)
        {
            string s = null;
            if (obj is string)
            {
                s = (string)obj;
                stringCount++;
            }
            else
                objectCount++;
        }
    }
