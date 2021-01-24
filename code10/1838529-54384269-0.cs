	var rand = new Random();
	
	var sourcesCounter = 4;
	
	IEnumerable<IObservable<Data>> sources =
		Enumerable
			.Range(0, sourcesCounter)
			.Select(x =>
				Observable
					.Interval(TimeSpan.FromSeconds(1))
					.Select(e => new Data()
					{
						currentDate = DateTime.Now, //let's assume it is round to seconds
						Samples = new List<double>(1000),
						IsValid = rand.Next(5) < 4 //Generate true/false randomly
					}));
			
		IObservable<IList<Data>> zipped = sources.Zip(values => values);
