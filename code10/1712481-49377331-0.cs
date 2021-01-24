	var input = "asd sdf dfg";
	var stringList = new List<string>();
	for (int i = 0; i < input.Length; i++)
	{
		for (int j = i; j < input.Length; j++)
		{
			var substring = input.Substring(i, j-i+1);
			stringList.Add(substring);
		}
	}
		
	foreach(var item in stringList)
	{
		Console.WriteLine(item);
	}
