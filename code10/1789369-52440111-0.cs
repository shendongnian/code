    public static void ExecuteSafely(Action callback, string command, 
		params (string Name, object Value)[] commandParameters)
	{
		foreach ((string Name, object Value) commandParameter in commandParameters)
		{
			string name = commandParameter.Name;
			object value = commandParameter.Value;
			// ...
		}
	}
