	static public void Main()
	{
		var sb = new StringBuilder();
		Test(c => NoValue(sb.Append(c)) );
		Test(c => sb.Append(c) );
	}
