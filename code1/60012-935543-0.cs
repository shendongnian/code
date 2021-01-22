	static void Main()
	{
		AppDomain.CurrentDomain.AssemblyResolve += OnResolveFailure;
		//...
	}
	static Assembly OnResolveFailure(object sender, ResolveEventArgs args)
	{
		//Do something here...
	}
