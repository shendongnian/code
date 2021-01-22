	public static class ThingExtensions
	{
		public static void Process<T>(this Thing<T> p)
			where T : IEnumerable<string>
		{
			// Do something with .Any().
			Console.WriteLine(p.Value.Any());
		}
	}
