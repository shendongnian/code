		static void Main(string[] args)
		{
			List<int> intList = new List<int>{ 1, 2, 3, 4 };
			foreach (List<int> set in PowerSet<int>.powerset(intList))
			{
				foreach (int i in set)
					Console.Write("{0} ", i);
				Console.WriteLine();
			}
		}
