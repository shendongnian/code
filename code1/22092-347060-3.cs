		static void Main(string[] args)
		{
			int[] intList = { 1, 2, 3, 4 };
			foreach (IList<int> set in PowerSet<int>.powerset(intList))
			{
				foreach (int i in set)
					Console.Write("{0} ", i);
				Console.WriteLine();
			}
		}
