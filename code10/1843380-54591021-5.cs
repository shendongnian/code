	public class CardColourComparer : IComparer<List<int>>
	{
		public static readonly CardColourComparer Instance = new CardColourComparer();
		private CardColourComparer() { }
		public int Compare(List<int> x, List<int> y)
		{
			// Exercise for the reader: null handling
			// For each list, compare elements. The lowest element wins
			for (int i = 0; i < Math.Min(x.Count, y.Count); i++)
			{
				int result = x[i].CompareTo(y[i]);
				if (result != 0)
				{
					return result;
				}
			}
			// If we're here, then either both lists are identical, or one is shorter, but it
            // has the same elements as the longer one.
			// In this case, the shorter list wins
			return x.Count.CompareTo(y.Count);
		}
	}
