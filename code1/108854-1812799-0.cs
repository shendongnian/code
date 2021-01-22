	var rootGroups = new List<IGroup>();
	var dic = groups.ToDictionary(g => g.ID);
	foreach (var g in groups)
	{
		if (g.ParentID == null)
		{
			rootGroups.Add(g);
		}
		else
		{
			IGroup parent;
			if (dic.TryGetValue(g.ParentID, out parent))
			{
				parent.Groups.Add(g);
			}
		}
	}
