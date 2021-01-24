	public void Traverse(List<Item> list)
	{
		var roots = list.Where(e => e.ParentId == 0).ToList();
		foreach (var item in roots)
		{
			Traverse(list, item);
			Console.WriteLine();
		}
	}
	private void Traverse(List<Item> list, Item target, string str = "")
	{
		str += target.Name;
		var children = list.Where(e => e.ParentId == target.Id).ToList();
		if (!children.Any())
		{
			Console.WriteLine(str);
			return;
		}
		str += ":";
		foreach (var item in children)
		{
			Traverse(list, item, str);
		}
	}
