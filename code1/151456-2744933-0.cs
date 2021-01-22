	public void DoSomething(string parameterA, int parameterB)
	{
		Console.WriteLine(parameterA+" : "+parameterB);
	}
	void Main()
	{
		
		var parameters = new object[]{"someValue", 5};
		Action<string,int> func=DoSomething;
		func.DynamicInvoke(parameters);
		
	}
