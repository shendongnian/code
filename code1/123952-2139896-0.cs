        public delegate void WorkCompletedCallBack(string result);
        public void DoWork(WorkCompletedCallBack callback)
        {
            callback("Hello world");
        }
        public void Test()
        {
            WorkCompletedCallBack callback = TestCallBack; // Notice that I am referencing a method without its parameter
            DoWork(callback);
        }
        public void TestCallBack(string result)
        {
            Console.WriteLine(result);
        }
