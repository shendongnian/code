    public static IObservable<T> CombineObservables<T>(
		IObservable<T> historicObservable,
		IObservable<T> currentObservable)
    	where T : IEquatable<T>
	{
		var cachedCurrent = currentObservable.Replay();
		cachedCurrent.Connect();
	
		var firstMessage = cachedCurrent.FirstAsync();
	
		var emittedHistoryItems = new List<T>();
			
		var part1 = historicObservable.TakeUntil(firstMessage)
									  .Do(x => emittedHistoryItems.Add(x));
		
		var part2 = historicObservable.CombineLatest(firstMessage, Tuple.Create)
									  .TakeWhile(x =>
												 {
													 var historyItem = x.Item1;
													 var first = x.Item2;
													 
													 return !emittedHistoryItems.Any(y => y.Equals(first)) && !historyItem.Equals(first);
												 })
									  .Select(x => x.Item1)
									  .Do(x => emittedHistoryItems.Add(x));
			
		var part3 = cachedCurrent.SkipWhile(x => emittedHistoryItems.Contains(x));
	
		return part1.Concat(part2).Concat(part3);
	}
