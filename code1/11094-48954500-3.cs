    private static List<int> quickie5(List<int> ites)
	{
		if (ites.Count <= 1)
			return ites;
		var piv = ites[0];
		List<int> les = new List<int>();
		List<int> sam = new List<int>();
		List<int> mor = new List<int>();
		Enumerable.Range(0, 3).AsParallel().ForAll(i =>
		{
			switch (i)
			{
				case 0: les = (from _item in ites where _item < piv select _item).ToList(); break;
				case 1: sam = (from _item in ites where _item == piv select _item).ToList(); break;
				case 2: mor = (from _item in ites where _item > piv select _item).ToList(); break;
			}
		});
		List<int> allofem = new List<int>();
		var _les = new List<int>();
		var _mor = new List<int>();
		Enumerable.Range(0, 2).AsParallel().ForAll(i =>
		{
			switch (i)
			{
				case 0: _les = quickie(les); break;
				case 1: _mor = quickie(mor); break;
			}
		});
		allofem.AddRange(_les);
		allofem.AddRange(sam);
		allofem.AddRange(_mor);
		return allofem;
	}
