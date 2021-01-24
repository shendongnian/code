	void Main()
	{
		var demo = new StringList(){"one","two","three","four"};
		Console.WriteLine(demo.MaxLength());
	}
	
	class StringList: List<string>
	{
		public int MaxLength()
		{
			return this.Max(s => s?.Length ?? 0); //handles nulls
		}
	}
