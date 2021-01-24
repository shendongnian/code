	List<List<string>> termsBatches = new List<List<string>>()
	{
		new List<string>() { "apple", "banana" },
		new List<string>() { "cat", "dog" },
	};
	
	IObservable<SolrSearchResults> query =
		from batch in termsBatches.ToObservable()
		from result in Observable.FromAsync(() => GetSolrSearchResults(batch))
		select result;
	
	IDisposable subscription =
		query
			.Subscribe(result =>
			{
				//Process result
			});
