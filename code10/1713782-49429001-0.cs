    public static class IEnumerableExtensions
	{
		public static void DisposeAll<T>(this IEnumerable<T> seq) where T : IDisposable
		{
			foreach (T d in seq)
				d.Dispose();
		}
	}
----------
    var connections = new List<SqlConnection>();
    // ...
    connections.DisposeAll();
