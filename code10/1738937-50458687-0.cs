	public sealed class Application
	{
		private Application()
		{
		}
		public void Foo(string input)
		{
			Console.WriteLine("The Foo method says '{0}'.", input);
		}
		static public Application GetInstance()
		{
			return new Application();
		}
	}
