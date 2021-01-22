	static class PowerSet<T>
	{
		static public IEnumerable<IList<T>> powerset(T[] currentGroupList)
		{
			int count = currentGroupList.Length;
			long max = 1L << count;
			for (long iter = 0; iter < max; iter++)
			{
				T[] list = new T[count];
				int k = 0, m = 0;
				long mask = 1L;
				for (long i = iter; i != 0; i &= (i - 1))
				{
					while ((mask & i) == 0)
					{
						++m;
						mask <<= 1;
					}
					list[k++] = currentGroupList[m];
				}
				yield return list;
			}
		}
	}
