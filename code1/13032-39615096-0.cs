		static void Main(string[] args)
		{
		  int loops = 10000000;
		  var data = Encoding.ASCII.GetBytes("123");
		  var hashLoop = new Action<HashAlgorithm>((HashAlgorithm ha) =>
		  {
			for (int i = 0; i < loops; i++)
			  ha.ComputeHash(data);
		  });
		  var t1 = Task.Factory.StartNew(() =>
		  {
			Time(hashLoop, new SHA512Managed());
		  });
		  var t2 = Task.Factory.StartNew(() =>
		  {
			Time(hashLoop, new SHA512Cng());
		  });
		  Task.WaitAll(t1, t2);
		  Console.WriteLine("Benchmark done!");
		  Console.ReadKey();
		}
		static void Time(Action<HashAlgorithm> action, HashAlgorithm ha)
		{
		  var sw = new Stopwatch();
		  sw.Start();
		  action(ha);
		  sw.Stop();
		  Console.WriteLine("{1} done in {0}ms", sw.ElapsedMilliseconds, ha.ToString());
		}
