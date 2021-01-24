    public static IObservable<T> CombineObservables<T>(
        IObservable<T> historicObservable,
        IObservable<T> currentObservable)
        where T : IEquatable<T>
    {
		var cachedCurrent = currentObservable.Replay();
		cachedCurrent.Connect();
			
		var firstMessage = cachedCurrent.FirstAsync();
			
		var part1 = historicObservable.TakeUntil(firstMessage)
									  .Do(x => Console.WriteLine($"History: {x}"));
			
		var part2 = historicObservable.CombineLatest(firstMessage, Tuple.Create)
			                          .TakeWhile(x =>
												 {
												     var historyItem = x.Item1;
													 var first = x.Item2;
														  
													 return !historyItem.Equals(first);
												 })
									  .Select(x => x.Item1)
									  .Do(x => Console.WriteLine($"History: {x}"))
									  .Finally(() => Console.WriteLine("!"));
			
		var part3 = cachedCurrent.Do(x => Console.WriteLine($"Current: {x}"));
			
        return part1.Concat(part2).Concat(part3);
    }
