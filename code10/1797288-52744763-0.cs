	var unique = table.GroupBy(x => x.SampleDt)
        .Where(g => g.Count() > 1)
        .AsEnumerable()  // probably needed for below 
		.SelectMany(g => g
			.Select((x, index) => new EntityName
				{ 
					SampleDt = x.SampleDt.AddMilliseconds(index),
					Value = x.Value
				}
			));
