	Func<IEnumerable<DomainTimeErrors>, bool> checkdiffrent = (items) =>
	{
	    var itemsCount=items.Count();
	    if (itemsCount == 0 || itemsCount == 1)
	      return true;
		
		var sortedItems=items.OrderBy(a=> a.FinishedAt.Value);
		var firstItem=sortedItems.First();
		var lastItem= sortedItems.Last();
		return (firstItem.FinishedAt- lastItem.FinishedAt).Value.TotalHours > 1;
	}
	var itemWithFinishDate = DomainTimeErrorsCollection.Where(a=> a.FinishedAt.HasValue).
	var result = itemWithFinishDate.GroupBy(i=> i.Url).
					Where(sameUrls => checkdiffrent(sameUrls))
					.SelectMany(a=> a);
