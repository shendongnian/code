    List<string> months = new List<string>();
    List<int> years = new List<int>();
    
    dates.ForEach(s =>
              	{
              		months.Add(s.Substring(0, 3));
              		years.Add(2000 + int.Parse(s.Substring(4, 2)));
              	});
