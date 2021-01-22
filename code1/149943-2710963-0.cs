		public static void Test()
		{
			var a = Enumerable.Range(0, 1000000).ToArray();
			var stopwatch = Stopwatch.StartNew();
			for(int i=0; i<1000; i++)
			{
				Array.Reverse(a);
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed Array.Reverse: " + stopwatch.ElapsedMilliseconds);
			stopwatch = Stopwatch.StartNew();
			for (int i = 0; i < 1000; i++)
			{
				MyReverse(a);
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed MyReverse: " + stopwatch.ElapsedMilliseconds);
		}
		private static void MyReverse(int[] a)
		{
			int j = a.Length - 1;
			for(int i=0; i<j; i++, j--)
			{
				int z = a[i];
				a[i] = a[j];
				a[j] = z;
			}
		}
