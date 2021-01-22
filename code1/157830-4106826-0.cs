    public static ThatAreWrapper<TSource> That<TSource>
		(this IEnumerable<TSource> source)
	{
		return new ThatAreWrapper<TSource>(source);
	}
	public class ThatAreWrapper<TSource>
	{
		private readonly IEnumerable<TSource> SourceCollection;
		public ThatAreWrapper(IEnumerable<TSource> source)
		{
			SourceCollection = source;
		}
		public IEnumerable<TResult> Are<TResult>() where TResult : TSource
		{
			foreach (var sourceItem in SourceCollection)
				if (sourceItem is TResult) yield return (TResult)sourceItem;
			}
		}
	}
