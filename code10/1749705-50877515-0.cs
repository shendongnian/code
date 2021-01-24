	public static void Main(string[] args)
	{
		var testSet = new string[]
		{
			"X", "O", "O",
			"O", "X", "O",
			"O", "X", "X"
		};
		var winner = GetWinner(testSet);
		if (winner != null)
		{
			Console.WriteLine($"{winner} wins!");
		}
	}
