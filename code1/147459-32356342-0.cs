    class Program
    {
        static void Main(string[] args)
        {
            TestClass.RunTest();
            Console.ReadLine();
        }
    }
    interface ITestClass
    {
        void TestMethod(object sender, TestEventArgs eventErgs);
    }
    class TestClass : ITestClass
    {
        #region Events
        event EventHandler<TestEventArgs> TestEvent;
        #endregion
        #region Constructor
        public TestClass()
        {
            TestEvent += TestMethod;
        }
        #endregion
        #region Public Methods
        public static void RunTest()
        {
            int testCount = 1000000000; //1 000 000 000
            string format = "{0:### ### ### ##0}";
            #region Direct Call
            Console.WriteLine("Direct call");
            TestClass testClass = new TestClass();
            testClass.TestMethod(testClass, new TestEventArgs(3));
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < testCount; ++i)
            {
                testClass.TestMethod(testClass, new TestEventArgs(3));
            }
            stopwatch.Stop();
            Console.WriteLine(string.Format(format, stopwatch.ElapsedMilliseconds));
            Console.WriteLine();
            #endregion
            #region Interface Call
            Console.WriteLine("Interface call");
            ITestClass itestClass = new TestClass();
            itestClass.TestMethod(testClass, new TestEventArgs(3));
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < testCount; ++i)
            {
                itestClass.TestMethod(testClass, new TestEventArgs(3));
            }
            stopwatch.Stop();
            Console.WriteLine(string.Format(format, stopwatch.ElapsedMilliseconds));
            Console.WriteLine();
            #endregion
            #region Delegate Call
            Console.WriteLine("Delegate call");
            TestClass delegateTestClass = new TestClass();
            Action<object, TestEventArgs> delegateMethod = delegateTestClass.TestMethod;
            delegateMethod(testClass, new TestEventArgs(3));
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < testCount; ++i)
            {
                delegateMethod(testClass, new TestEventArgs(3));
            }
            stopwatch.Stop();
            Console.WriteLine(string.Format(format, stopwatch.ElapsedMilliseconds));
            Console.WriteLine();
            #endregion
            #region Event Call
            Console.WriteLine("Event call");
            TestClass eventTestClast = new TestClass();
            eventTestClast.TestEvent(testClass, new TestEventArgs(3));
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < testCount; ++i)
            {
                eventTestClast.TestEvent(testClass, new TestEventArgs(3));
            }
            stopwatch.Stop();
            Console.WriteLine(string.Format(format, stopwatch.ElapsedMilliseconds));
            Console.WriteLine();
            #endregion
        }
        #endregion
        #region ITestClass Members
        public void TestMethod(object sender, TestEventArgs e)
        {
            e.Result = e.Value * 3;
        }
        #endregion
    }
    class TestEventArgs : EventArgs
    {
        public int Value { get; private set; }
        public int Result { get; set; }
        public TestEventArgs(int value)
        {
            Value = value;
        }
    }
