    public void PrintAllSuits()
		{
			foreach(string suit in Enum.GetNames(typeof(Suits)))
			{
				Console.WriteLine(suit);
			}
		}
