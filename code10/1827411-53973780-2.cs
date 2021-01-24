	private delegate void Iterator();
	[CompilerGenerated]
	private sealed class CompGenCls
	{
		public int i;
		internal void CompGenFunc()
		{
			Console.WriteLine(i);
		}
	}
	private static void Main(string[] args)
	{
		List<Iterator> iterators = new List<Iterator>();
		CompGenCls obj = new CompGenCls();
		obj.i = 0;
        for (; obj.i < 15; obj.i++)
        {
            iterators.Add(obj.CompGenFunc);
        }
		foreach (Iterator item in iterators)
		{
			item();
		}
		Console.Read();
	}
