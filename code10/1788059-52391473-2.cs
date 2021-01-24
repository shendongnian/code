	IList<string> messages;
	bool isValidSchema = data.IsValid(schema, out messages);
	foreach (string message in messages)
	{
		Console.WriteLine(message);
	}
