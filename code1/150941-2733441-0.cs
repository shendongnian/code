	List<List<int>> lists = new List<List<int>>();
	lists.Add(new List<int>());
	lists.Add(new List<int>());
	lists[0].Add(1);
	lists[0].Add(2);
	lists[1].Add(3);
	lists[1].Add(4);
	
	var result = lists.SelectMany(x => x);  // results in 1, 2, 3, 4
