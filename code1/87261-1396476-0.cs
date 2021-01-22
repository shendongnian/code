		static void Main(string[] args)
		{
			int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
			List<int[]> items = new List<int[]>(SplitArray(values, 4));
		}
		static IEnumerable<T[]> SplitArray<T>(T[] items, int size)
		{
			for (int index = 0; index < items.Length; index += size)
			{
				int remains = Math.Min(size, items.Length-index);
				T[] segment = new T[remains];
				Array.Copy(items, index, segment, 0, remains);
				yield return segment;
			}
		}
