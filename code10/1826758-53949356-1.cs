	static public void Main()
	{
		var sb = new StringBuilder();
		Test(action: c => sb.Append(c) );
		Test(func: c => sb.Append(c) );
	}
