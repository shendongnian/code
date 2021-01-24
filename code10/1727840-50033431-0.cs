	var finalDictionary =
		dictionaryOne
			.Concat(dictionaryTwo)
			.Concat(dictionaryThree)
			.GroupBy(x => new { x.Key.Property1, x.Key.Property2 }, x => x.Value)
			.ToDictionary(x => new { x.Key.Property1, x.Key.Property2 }, x => x.Sum());
