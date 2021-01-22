        public void DoWork(Action<string> callback)
        {
            callback("Hello world");
        }
        public void Test()
        {
            DoWork((result) => Console.WriteLine(result));
        }
