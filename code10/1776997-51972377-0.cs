    List<string> split = new List<string>(s.Split(','));
    string first = split[0];
    split.RemoveAt(0);
    List<List<string>> result = new List<List<string>>();
    foreach (var dist in split.Select(o => o.Split('.')[0]).Distinct())
    {
    	List<string> temp = new List<string> {first};
    	temp.AddRange(split.Where(o => o.StartsWith(dist)));
    	result.Add(temp);
    }
