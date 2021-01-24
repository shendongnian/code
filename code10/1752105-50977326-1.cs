		var merged = items
			.GroupBy(x => x.GroupingKey)
			.Select(grp => new Item
			{
				Values = Enumerable
					.Range(0, grp.Max(x => x.Values.Count))
					.Select(i => grp.Sum(x => x.Values.Count > i ? x.Values[i] : 0))
					.ToList(),
				GroupingKey = grp.Key,
				Cycle = grp.First().Cycle   // can add check that others are identical
			})
			.ToList();
