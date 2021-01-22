	class Program {
		static void Main(string[] args) {
			const int steps = 10000;
			Stopwatch sw = new Stopwatch();
			ArrayList list1 = new ArrayList();
			sw.Start();
			for(int i = 0; i < steps; i++) {
				list1.Add(i);
			}
			sw.Stop();
			Console.WriteLine("ArrayList:\tMilliseconds = {0},\tTicks = {1}", sw.ElapsedMilliseconds, sw.ElapsedTicks);
			MyList list2 = new MyList();
			sw.Start();
			for(int i = 0; i < steps; i++) {
				list2.Add(i);
			}
			sw.Stop();
			Console.WriteLine("MyList:  \tMilliseconds = {0},\tTicks = {1}", sw.ElapsedMilliseconds, sw.ElapsedTicks);
