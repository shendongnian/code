	static class PowerSet<T>
	{
		static Dictionary<long, int> powerToIndex = new Dictionary<long, int>();
		static PowerSet()
		{
			for (int i = 0; i < 64; i++)
				powerToIndex[1L << i] = i;
		}
		static public IEnumerable<List<T>> powerset(List<T> currentGroupList)
		{
			long max = 1L << currentGroupList.Count;
			for (long i = 0; i < max; i++)
				yield return powerlist(currentGroupList, i);
		}
		static private List<T> powerlist(List<T> currentGroupList, long i)
		{
			List<T> list = new List<T>(currentGroupList.Count);
			while (i != 0)
			{
				long j = i & (i - 1);
				long nextBit = i ^ j;
				int nextIndex = powerToIndex[nextBit];
				list.Add(currentGroupList[nextIndex]);
				i = j;
			}
			return list;
		}
	}
