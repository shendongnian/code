	var tagPredicate = PredicateBuilder.True<MainEntity>();
	if (tagSearchValues.Any())
	{
		tagPredicate = PredicateBuilder.False<MainEntity>();
		foreach (var tag in tagSearchValues)
		{
			tagPredicate = tagPredicate.Or(m => m.Tags
                               .Any(t => t.Key == tag.Key
                                      && t.Value == tag.Value));
		}
	}
	var query = _dbContext.MainEntities
		.Where(m => string.IsNullOrWhiteSpace(stuff) || m.Stuff == stuff)
		.Where(tagPredicate);
    ... // Use query
