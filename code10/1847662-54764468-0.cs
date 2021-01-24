	IEnumerable<Item> data = new List<Item>
	{
			new Item { Id = 1, Value = 1, Dt = DateTime.Parse("2018-12-03 08:00:00")},
			new Item { Id = 2, Value = 1, Dt = DateTime.Parse("2018-12-03 08:01:00")},
			new Item { Id = 3, Value = 1, Dt = DateTime.Parse("2018-12-03 08:02:00")},
			new Item { Id = 4, Value = 1, Dt = DateTime.Parse("2018-12-03 08:03:00")},
			new Item { Id = 5, Value = 1, Dt = DateTime.Parse("2018-12-03 08:04:00")},
			new Item { Id = 6, Value = 1, Dt = DateTime.Parse("2018-12-03 08:05:00")},
			new Item { Id = 6, Value = 1, Dt = DateTime.Parse("2018-12-03 08:06:00")},
			new Item { Id = 7, Value = 1, Dt = DateTime.Parse("2018-12-03 08:15:00")},
			new Item { Id = 8, Value = 1, Dt = DateTime.Parse("2018-12-03 08:16:00")},
			new Item { Id = 9, Value = 1, Dt = DateTime.Parse("2018-12-03 08:17:00")},
			new Item { Id = 10, Value = 1, Dt = DateTime.Parse("2018-12-03 08:18:00")},
			new Item { Id = 11, Value = 1, Dt = DateTime.Parse("2018-12-03 08:19:00")},
			new Item { Id = 12, Value = 1, Dt = DateTime.Parse("2018-12-03 08:20:00")},
		};
	var scheduler = new HistoricalScheduler(DateTime.Parse("2018-12-03 08:00:00"));
	var source =
		Observable
			.Generate(
				data.GetEnumerator(),
				events => events.MoveNext(),
				events => events,
				events => events.Current,
				events => events.Current.Dt,
				scheduler);
	source
		.Window(TimeSpan.FromMinutes(5), scheduler)
		.SelectMany(stream =>
			stream
				.Aggregate(
					new Item() { Value = 0, Dt = scheduler.Now.DateTime },
					(a, x) => new Item()
					{
						Value = a.Value + x.Value,
						Dt = x.Dt,
					}))
		.Subscribe(s => Console.WriteLine($"v:{s.Value} t:{s.Dt}"));
	scheduler.Start();
