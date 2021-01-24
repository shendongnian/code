	var delimiters = "@#$<,\\.\t ";
	
	var lines =
		delimiters
			.Select(d => new
			{
				delimiter = d,
				lines =
					Enumerable
						.Range(0, 1000)
						.Select(n => String.Join(d.ToString(), Enumerable.Repeat("qwasdasdasde", 10)))
						.ToArray() 
			})
			.ToDictionary(x => x.delimiter, x => x.lines);
			
	var trials = 
		delimiters
			.ToDictionary(x => x, x => TimeSpan.Zero);
			
	foreach (var i in Enumerable.Range(0, 1000))
	{
		foreach (var delimiter in delimiters)
		{
			var sw = Stopwatch.StartNew();
			File.WriteAllLines("test.txt", lines[delimiter]);
			trials[delimiter] = trials[delimiter].Add(sw.Elapsed);
		}
	}
