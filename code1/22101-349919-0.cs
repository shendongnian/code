	static class PowerSet4<T>
	{
		static public IEnumerable<IList<T>> powerset(T[] currentGroupList)
		{
			int count = currentGroupList.Length;
			Dictionary<long, T> powerToIndex = new Dictionary<long, T>();
			long mask = 1L;
			for (int i = 0; i < count; i++)
			{
				powerToIndex[mask] = currentGroupList[i];
				mask <<= 1;
			}
			Dictionary<long, T> result = new Dictionary<long, T>();
			yield return result.Values.ToArray();
			long max = 1L << count;
			for (long i = 1L; i < max; i++)
			{
				long key = i & -i;
				if (result.ContainsKey(key))
					result.Remove(key);
				else
					result[key] = powerToIndex[key];
				yield return result.Values.ToArray();
			}
		}
	}
