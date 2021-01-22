	public static class MainClass {
		private delegate void TestDelegate(string x);
		private static void A(string x) {}
		private static void Invoke(TestDelegate test, string s) {
			Delegate[] delegates = test.GetInvocationList();
			IAsyncResult[] results = new IAsyncResult[delegates.Length];
			for (int i = 0; i < delegates.Length; i++) {
				results[i] = ((TestDelegate)delegates[i]).BeginInvoke("string", null, null);
			}
			for (int i = 0; i < delegates.Length; i++) {
				((TestDelegate)delegates[i]).EndInvoke(results[i]);
			}
		}
		public static void Main(string[] args) {
			Console.WriteLine("Warm-up call");
			TestDelegate test = A;
			test += A;
			test += A;
			test += A;
			test += A;
			test += A;
			test += A;
			test += A;
			test += A;
			test += A; // 10 times in the invocation list
			ParallelInvoke.Invoke(test, "string"); // warm-up
			Stopwatch sw = new Stopwatch();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Console.WriteLine("Profiling calls");
			sw.Start();
			for (int i = 0; i < 100000; i++) {
				// ParallelInvoke.Invoke(test, "string"); // profiling ParallelInvoke
				Invoke(test, "string"); // profiling native BeginInvoke/EndInvoke
			}
			sw.Stop();
			Console.WriteLine("Done in {0} ms", sw.ElapsedMilliseconds);
			Console.ReadKey(true);
		}
	}
