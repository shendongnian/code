    static class ExtensionMethods
	{
		public static IEnumerable<TOut> Accumulate<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn,double> getFunction, Func<TIn,double,TOut> createFunction)
		{
			double accumulator = 0;
			
			foreach (var item in source)
			{
				accumulator += getFunction(item);
				yield return createFunction(item, accumulator);
			}
		}
	}
