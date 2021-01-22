	for (int i = 0; i < 10; i++)
	{
		string initializeme = string.Empty;
		if (expressionThatEvalsFalse)
			initializeme = SomeMethodReturningString();
		
		Console.WriteLine(initializeme);
	}
