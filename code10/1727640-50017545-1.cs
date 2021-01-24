	var List2copy = List2.ToList();
	if (List1.Count != List2.Count) return false;
	return List1.All(x =>
	{
		int index = List2copy.FindIndex(y => new MyEqualityComparer<int>().Equals(x, y));
		if (index == -1) return false;
		List2copy.RemoveAt(index);
		return true;
	});
