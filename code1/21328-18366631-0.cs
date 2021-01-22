	//This causes the output to update on the same line, rather than "spamming" the output down the screen.
	//This is not compatible with redirected output, so try/catch is needed.
	try
	{
		int lineLength = Console.WindowWidth - 1;
		if (message.Length > lineLength)
		{
			message = message.Substring(0, lineLength);
		}
		Console.CursorLeft = 0;
		Console.Write(message);
	}
	catch 
	{
		Console.WriteLine(message);
	}
