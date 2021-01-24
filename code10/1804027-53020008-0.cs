    private class Single
	{
		private static readonly Single s;
		static Single()
		{
			Console.WriteLine("static");
			s = new Single();
		}
	}
