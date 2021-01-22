		public static IEnumerable<T> Invert<T>(this IEnumerable<T> source, int index, int count)
		{
			var transform = source.Select(
				(o, i) => new
				{
					Index = i < index ? Int32.MaxValue : i >= index + count ? Int32.MinValue : i,
					Object = o
				});
			return transform.OrderByDescending(o => o.Index)
							.Select(o => o.Object);
		}
