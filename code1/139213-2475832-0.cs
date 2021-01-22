	static void Main()
	{
		var a = Enumerable.Range(0, 1000000);
		var b = new List<int>();
		for (int i = 0; i < 1000000; i += 10)
		{
			b.Add(i);
		}
		Stopwatch sw = new Stopwatch();
		sw.Start();
		var c = a.Except(b).ToList();
		sw.Stop();
		Console.WriteLine("Milliseconds {0}", sw.ElapsedMilliseconds );
		sw.Reset();
		Console.ReadLine();
	}
