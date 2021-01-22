	public static void Fill<T>(this Array source, T value)
	{
		Fill(0, source, new long[source.Rank], value);
	}
	static void Fill<T>(int dimension, Array array, long[] indexes, T value)
	{
		var lowerBound = array.GetLowerBound(dimension);
		var upperBound = array.GetUpperBound(dimension);
		for (int i = lowerBound; i < upperBound; i++)
		{
			indexes[dimension] = i;
			if (dimension < array.Rank - 1)
			{
				Fill(dimension + 1, array, indexes, value);
			}
			else
			{
				array.SetValue(value, indexes);
			}
		}
	}
