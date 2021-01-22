	public class DepthAware<T> : IEnumerable<T>
	{
		private readonly IEnumerable<T> source;
		public DepthAware(IEnumerable<T> source)
		{
			this.source = source;
			this.Depth = 0;
		}
		public int Depth { get; private set; }
		private IEnumerable<T> GetItems()
		{
			foreach (var item in source)
			{
				++this.Depth;
				yield return item;
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			return GetItems().GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	// generic type leverage and extension invoking
	public static class DepthAware
	{
		public static DepthAware<T> AsDepthAware<T>(this IEnumerable<T> source)
		{
			return new DepthAware<T>(source);
		}
		public static DepthAware<T> New<T>(IEnumerable<T> source)
		{
			return new DepthAware<T>(source);
		}
	}
