    class Program
    {
        const string CategoryName = "____Test Category";
        const string CounterName = "Clear State Operations";
            
        static void Main(string[] args)
        {
            if (PerformanceCounterCategory.Exists(CategoryName))
                PerformanceCounterCategory.Delete(CategoryName);
            var counterDataCollection = new CounterCreationDataCollection();
            var clearStateCounterData = new CounterCreationData()
            {
                CounterName = CounterName,
                CounterHelp = "The number of times the service state has been cleared since the last performance iteration",
                CounterType = PerformanceCounterType.CounterDelta32
            };
            counterDataCollection.Add(clearStateCounterData);
            PerformanceCounterCategory.Create(CategoryName, "Test Perf Counters", PerformanceCounterCategoryType.SingleInstance, counterDataCollection);
            var counter = new PerformanceCounter(CategoryName, CounterName, false);
            for (int i = 0; i < 5000; i++)
            {
                var sw = Stopwatch.StartNew();
                Thread.Sleep(10300);
                sw.Stop();
                counter.Increment();
            }
            Console.Read();
        }
    }
