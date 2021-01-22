    var missing = counters
	.Where(counter => !PerformanceCounterCategory.CounterExists(counter.Name, CategoryName))
    .Count();
	if (missing > 0)
	{
		PerformanceCounterCategory.Delete(CategoryName);
		PerformanceCounterCategory.Create(
			CategoryName,
			CategoryHelp,
			PerformanceCounterCategoryType.MultiInstance,
			new CounterCreationDataCollection(counters.Select(x => (CounterCreationData)x).ToArray()));
	}
