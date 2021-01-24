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
		while (obj.i < 15)
		{
			iterators.Add(CompGenCls.CompGenFunc);
			obj.i++;
		}
		foreach (Iterator item in iterators)
		{
			item();
		}
		Console.Read();
	}
