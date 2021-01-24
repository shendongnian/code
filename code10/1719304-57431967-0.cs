    class Program
	{
		static void Main(string[] args)
		{
			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			for (int i = 0; i < 10_000_000; i++)
			{
				IsSafe("POST");
			}
			watch.Stop();
			Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
			Console.ReadLine();
		}
		//static readonly HashSet<string> safeMethods = new HashSet<string>(new[] { "GET", "OPTIONS", "HEAD", "TRACE" });
		static readonly string[] safeMethods = new[] { "GET", "OPTIONS", "HEAD", "TRACE" };
		static bool IsSafe(string method)
		{
			//var safeMethods = new[] { "GET", "OPTIONS", "HEAD", "TRACE" };
			return safeMethods.Contains(method, StringComparer.InvariantCultureIgnoreCase);
		}
	}
