    List<Tuple<string, string, DateTime>> latestAdded = new List<Tuple<string, string, DateTime>>();
	var item = latestAdded.Where(x => x.Item1 == newdata.name && x.Item2 == newdata.number).FirstOrDefault();
	if (item == null)
	{
		latestAdded.Add(new Tuple<string, string, DateTime>(newdata.name, newdata.number, newdata.updatedAt));
	}
	else
	{
		if(item.updatedAt > newdata.updatedAt)
		{
			item.updatedAt = newdata.updatedAt;
		}
	}
