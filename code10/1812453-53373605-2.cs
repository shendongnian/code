    var list = new List<MP3objectSmall>();
	var s1 = new MP3objectSmall { SongName = "abc" };
	var s2 = new MP3objectSmall { SongName = "def" };
	var s3 = new MP3objectSmall { SongName = "xyz" };
	var s4 = new MP3objectSmall { SongName = "xxx" };
		
	list.Add(s1);
	list.Add(s2);
	list.Add(s3);
	list.Add(s4);
		
	var filteredList = list.Where(i => i.SongName.StartsWith("x")).ToList();
									  
	foreach(var item in filteredList)
	{
		Console.WriteLine(item.SongName);
	}
