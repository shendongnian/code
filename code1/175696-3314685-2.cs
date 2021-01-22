	class Peekable<T>
	{
		public Peekable(T current, T next)
		{
			Current = current;
			Next = next;
		}
		public T Current { get; private set; }
		public T Next { get; private set; }
	}
	static class PeekableAdaptor
	{
		public static IEnumerable<Peekable<T>> ToPeekable<T>(this IEnumerable<T> stream)
		{
			var source = stream.GetEnumerator();
			if (!source.MoveNext()) 
				yield break;
			T prev = source.Current;
			while (source.MoveNext())
			{
				yield return new Peekable<T>(prev, source.Current);
				prev = source.Current;
			}
			yield return new Peekable<T>(prev, default(T));
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			foreach (var pair in Enumerable.Range(1, 10).ToPeekable())
			{
				Console.WriteLine(pair.Current, pair.Next);
			}
		}
	}
