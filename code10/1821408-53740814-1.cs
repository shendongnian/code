    public static int GetIndex<T>(IList<T> largeList, IList<T> sublist)
	{
		for (int i = 0; i < largeList.Count - sublist.Count; i++)
		{
			bool isContained = largeList.Skip(i).Take(sublist.Count).SequenceEqual(sublist);
			if (isContained)
				return i;
		}
		return -1;
	}
