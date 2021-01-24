	private static List<string> MakeAList(Dog[] dogs)
	{
		List<string> dogList = new List<string>();
		for (int i = 0; i < dogs.Length; i++)
		{
			dogList.Add(dogs[i].Name);
		}
        return dogList;
	}
