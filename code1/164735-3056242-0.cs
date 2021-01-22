    internal class Program {
		
		private static List<int> CreateList(int size) {
			// use the same seed so that every list has the same elements
			Random random = new Random(589134554);
			List<int> list = new List<int>(size);
			for (int i = 0; i < size; ++i)
				list.Add(random.Next());
			return list;
		}
		private static void Benchmark(int size, bool output = true) {
			List<int> list1 = CreateList(size);
			List<int> list2 = CreateList(size);
			Stopwatch stopwatch = Stopwatch.StartNew();
			list1.Sort();
			stopwatch.Stop();
			double elapsedSort = stopwatch.Elapsed.TotalMilliseconds;
			if (output)
				Console.WriteLine("List({0}).Sort(): {1}ms (100%)", size, elapsedSort);
			stopwatch.Restart();
			list2.OrderBy(i => i).ToList();
			stopwatch.Stop();
			double elapsedOrderBy = stopwatch.Elapsed.TotalMilliseconds;
			if (output)
				Console.WriteLine("List({0}).OrderBy(): {1}ms ({2:.00%})", size, elapsedOrderBy, elapsedOrderBy / elapsedSort);
		}
		internal static void Main() {
			// ensure linq library is loaded and initialized
			Benchmark(1000, false);
			Benchmark(10);
			Benchmark(100);
			Benchmark(1000);
			Benchmark(10000);
			Benchmark(100000);
			Benchmark(1000000);
			Console.ReadKey();
		}
	}
