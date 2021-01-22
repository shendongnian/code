	public static IEnumerable<T> TakeLastN<T>(this IEnumerable<T> source, int n)
	{
		if (source == null)
			throw new ArgumentNullException("Source cannot be null");
		int goldenIndex = source.Count() - n;
		return source.SkipWhile((val, index) => index < goldenIndex);
	}
	
	//Or if you like them one-liners (in the spirit of the current accepted answer);
	//However, this is most likely impractical due to the repeated calculations
	collection.SkipWhile((val, index) => index < collection.Count() - N)
