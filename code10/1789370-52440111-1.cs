    public static void ExecuteSafely(Action callback, string command, 
		params (string name, object value)[] commandParameters)
	{
		foreach ((string Name, object Value) commandParameter in commandParameters)
		{
			string name = commandParameter.Name;
			object value = commandParameter.Value;
			// ...
		}
	}
