    class Program
    {
        static void Main(string[] args)
        {
            MyGuardedClass c = new MyGuardedClass();
            RunTest(c, TestNoLock);
            RunTest(c, TestWithLock);
            RunTest(c, TestWithDisposedLock);
            RunTest(c, TestWithCrossThreading);
            Console.ReadLine();
        }
        static void RunTest(MyGuardedClass c, Action<MyGuardedClass> testAction)
        {
            try
            {
                testAction(c);
                Console.WriteLine("SUCCESS: Result = {0}", c);
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL: {0}", ex.Message);
            }
        }
        static void TestNoLock(MyGuardedClass c)
        {
            c.ID = 1;
            c.Name = "Test1";
        }
        static void TestWithLock(MyGuardedClass c)
        {
            using (c.Lock())
            {
                c.ID = 2;
                c.Name = "Test2";
            }
        }
        static void TestWithDisposedLock(MyGuardedClass c)
        {
            using (c.Lock())
            {
                c.ID = 3;
            }
            c.Name = "Test3";
        }
        static void TestWithCrossThreading(MyGuardedClass c)
        {
            using (c.Lock())
            {
                c.ID = 4;
                c.Name = "Test4";
                ThreadPool.QueueUserWorkItem(s => RunTest(c, cc => cc.ID = 5));
                Thread.Sleep(2000);
            }
        }
    }
