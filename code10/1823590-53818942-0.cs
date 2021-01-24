    public static int GetInsertIndex<T>(List<T> list, T item)
	{
		int nextHigherIndex = list.BinarySearch(item);
		return nextHigherIndex < 0 ? Math.Abs(nextHigherIndex) - 1 : nextHigherIndex + 1;
	}
