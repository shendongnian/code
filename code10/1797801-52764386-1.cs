    string[] foldernames = Directory.GetDirectories(@"c:\MainFolder\");
	List<DateTime> result =  new List<DateTime>();
	foreach (var element in foldernames)
	{
		result.Add(DateTime.Parse(element.Substring(0,2)+"-"+element.Substring(2)));
	}
	result.OrderByDescending(d => d).Select(s => new {SortedFile = s.ToShortDateString().Replace(@"/1/","")});
