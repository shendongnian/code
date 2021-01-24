	public static IEnumerable<T> ToSingleDimension<T>(this T[,] source)
	{
		for (int i=0; i<=source.GetUpperBound(1); i++)
		{
			for (int j=0; j<=source.GetUpperBound(0); j++)
			{
				yield return source[j,i];
			}
		}
	}
