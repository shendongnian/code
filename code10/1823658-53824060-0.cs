    static void Run()
    {
        System.Collections.Generic.IEnumerable<int> getWorkItems()
        {
            int workCount = 9999;
            while (workCount > 0)
            {
                System.Console.Write($"R");
                yield return workCount--;
                Thread.Sleep(10);
            }
        }
        System.Threading.Tasks.Parallel.ForEach(
            getWorkItems(),
            (workItem) => System.Console.Write($"."));
    }
