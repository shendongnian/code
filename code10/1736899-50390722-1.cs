	Func<IEnumerable<DomainTimeErrors>, bool> checkdiffernt = (items) =>
	{
	    if ((new int[]{0,1}).Contains(items.Count()))
	       return true;
		
		var sortedItems=items.OrderBy(a=> a.FinishedAt.Value);
		var firstItem=sortedItems.First();
		var lastItem= sortedItems.Last();
		return (firstItem.FinishedAt- lastItem.FinishedAt).Value.TotalHours > 1;
	}
	var itemWithFinishDate = DomainTimeErrorsCollection.Where(a=> a.FinishedAt.HasValue).
	var result = itemWithFinishDate.GroupBy(i=> i.Url).
					Where(sameUrls => checkdiffernt(sameUrls))
					.SelectMany(a=> a);
