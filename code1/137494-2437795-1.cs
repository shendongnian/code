		static void Main(string[] args)
		{
			Thread.CurrentThread.Priority = ThreadPriority.Highest;
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
			List<String> rndTimes = new List<String>();
			List<String> orderedTimes = new List<String>();
			rndTimes.Add(TimeIt(50, RandomInsert));
			rndTimes.Add(TimeIt(100, RandomInsert));
			rndTimes.Add(TimeIt(200, RandomInsert));
			rndTimes.Add(TimeIt(400, RandomInsert));
			rndTimes.Add(TimeIt(800, RandomInsert));
			rndTimes.Add(TimeIt(1000, RandomInsert));
			rndTimes.Add(TimeIt(2000, RandomInsert));
			rndTimes.Add(TimeIt(4000, RandomInsert));
			rndTimes.Add(TimeIt(8000, RandomInsert));
			rndTimes.Add(TimeIt(16000, RandomInsert));
			rndTimes.Add(TimeIt(32000, RandomInsert));
			rndTimes.Add(TimeIt(64000, RandomInsert));
			rndTimes.Add(TimeIt(128000, RandomInsert));
			orderedTimes.Add(TimeIt(50, OrderedInsert));
			orderedTimes.Add(TimeIt(100, OrderedInsert));
			orderedTimes.Add(TimeIt(200, OrderedInsert));
			orderedTimes.Add(TimeIt(400, OrderedInsert));
			orderedTimes.Add(TimeIt(800, OrderedInsert));
			orderedTimes.Add(TimeIt(1000, OrderedInsert));
			orderedTimes.Add(TimeIt(2000, OrderedInsert));
			orderedTimes.Add(TimeIt(4000, OrderedInsert));
			orderedTimes.Add(TimeIt(8000, OrderedInsert));
			orderedTimes.Add(TimeIt(16000, OrderedInsert));
			orderedTimes.Add(TimeIt(32000, OrderedInsert));
			orderedTimes.Add(TimeIt(64000, OrderedInsert));
			orderedTimes.Add(TimeIt(128000, OrderedInsert));
			var result = string.Join("\n", (from s in rndTimes
							join s2 in orderedTimes
								on rndTimes.IndexOf(s) equals orderedTimes.IndexOf(s2)
							select String.Format("{0} \t\t {1}", s, s2)).ToArray());
			Console.WriteLine(result);
			Console.WriteLine("Done");
			Console.ReadLine();
		}
		static double StandardDeviation(List<double> doubleList)
		{
			double average = doubleList.Average();
			double sumOfDerivation = 0;
			foreach (double value in doubleList)
			{
				sumOfDerivation += (value) * (value);
			}
			double sumOfDerivationAverage = sumOfDerivation / doubleList.Count;
			return Math.Sqrt(sumOfDerivationAverage - (average * average));
		}
		static String TimeIt(int insertCount, Action<int> f)
		{
			Console.WriteLine("TimeIt({0}, {1})", insertCount, f.Method.Name);
			List<double> times = new List<double>();
			for (int i = 0; i < ITERATION_COUNT; i++)
			{
				Stopwatch sw = Stopwatch.StartNew();
				f(insertCount);
				sw.Stop();
				times.Add(sw.Elapsed.TotalMilliseconds);
			}
			return String.Format("{0:f4} (stddev {1:f4})", times.Average(), StandardDeviation(times));
		}
