	var finalDictionary =
	(
		from x in dictionaryOne.Concat(dictionaryTwo).Concat(dictionaryThree)
		group x.Value by new { x.Key.Property1, x.Key.Property2 }
	)
		.ToDictionary(x => new { x.Key.Property1, x.Key.Property2 }, x => x.Sum());
