    using System.Threading.Tasks;
	static void RunConcurrentThreads(List<Item> list, Action<Item> action, int nNumberOfConcurrentThreads = 3)
    {
        Parallel.ForEach
        (
			list,
            new ParallelOptions { MaxDegreeOfParallelism = nNumberOfConcurrentThreads  }
            i => action(i)
		);
    }
