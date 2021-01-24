        List<string> postcodes = new List<string>();
		postcodes.Add("EC1V 2DD");
		postcodes.Add("EC1M 51D");
		
		var query = postcodes.Select(x => x.Split(' ')[1]).ToList();
		foreach(var item in query)
		{
			Console.WriteLine(item);
		}
