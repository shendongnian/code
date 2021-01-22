	private static Dictionary<DateTime, double> CreateAggregatedDictionaryByDate(IEnumerable<TimeEntry> timeEntries)
	{
		return timeEntries.Aggregate(new Dictionary<DateTime, double>(),
		                             (accumulator, entry) =>
		                             	{
		                             		double value;
		                             		accumulator.TryGetValue(entry.Date, out value);
		                             		accumulator[entry.Date] = value + entry.Hours;
		                             		return accumulator;
		                             	});
	}
