	public void Write()
	{
		Console.Write("Data: ");
		Console.Write($"{data}");
		var next = link;
		while(next != null)
		{
			Console.Write($", {link.data}");
			next = next.link;
		}
	}
