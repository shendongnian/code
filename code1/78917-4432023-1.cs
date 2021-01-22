        public void TestMemoize()
        {
            Func<int, string> mainFunc = i =>
                                         {
                                             Console.WriteLine("Evaluating " + i);
                                             Thread.Sleep(1000);
                                             return i.ToString();
                                         };
            var memoized = mainFunc.Memoize();
            Parallel.ForEach(
                Enumerable.Range(0, 10),
                i => Parallel.ForEach(Enumerable.Range(0, 10), j => Console.WriteLine(memoized(i))));
        }
