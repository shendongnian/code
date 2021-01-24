	public class Comparer : IComparer<Tuple3>
	{
		public int Compare(Tuple3 first, Tuple3 second)
		{
			if (first.Item1 == second.Item1)
				return first.Item2.CompareTo(second.Item2);
			else
				return first.Item1.CompareTo(second.Item1);
		}
	}
	
	public class Tuple3
	{
		public int Item1;
		public int Item2;
		public int Item3;
	}
