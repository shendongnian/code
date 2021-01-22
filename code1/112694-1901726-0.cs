	public static class RandomizeExtensionMethods
	{
		private static readonly Random _random = new Random();
		public static IEnumerable<T> Randomize<T>(this IList<T> enumerable)
		{
			if (enumerable == null || enumerable.Count == 0)
			{
				return new List<T>(0);
			}
			return RandomizeImpl(enumerable);			
		}
		public static IEnumerable<T> RandomizeImpl<T>(this IList<T> enumerable)
		{
			var indices = new int[enumerable.Count];
			for(int i=0; i<indices.Length; i++)
			{
				indices[i] = i;
			}
			lock (_random)
			{
				for (int i = 0; i < indices.Length - 1; i++)
				{
					int j = _random.Next(i, indices.Length);
					int swap = indices[j];
					indices[j] = indices[i];
					indices[i] = swap;
				}
			}
			for(int i=0; i<indices.Length; i++)
			{
				yield return enumerable[indices[i]];
			}
		}
	}
