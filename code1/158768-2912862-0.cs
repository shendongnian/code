	class Program
	{
		static void Main(string[] args)
		{
			var foo = new Foo();
			foreach(var result in foo.Bar())
			{
				Console.WriteLine(result);
			}
			Console.ReadLine();
		}
	}
	class Foo
	{
		public IEnumerable<char> Bar()
		{
			const char start = 'a';
			for(int x = 0;x < 26;x++)
			{
				yield return (char)(start + x);
			}
		}
	}
