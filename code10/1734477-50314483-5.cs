	var subscription =
		Observable
			.Defer(() =>
			{
				var c = int.MaxValue;
				return
					current
						.Do(x => { if (c == int.MaxValue) c = x; })
						.Select(x => new { source = "current", value = x })
						.Publish(pc =>
							historic
								.TakeWhile(h => h < c)
								.Finally(() => Console.WriteLine("!"))
								.Select(x => new { source = "historic", value = x })
								.Publish(ph =>
									Observable
										.Merge(
											ph.Delay(x => pc.FirstOrDefaultAsync(y => x.value < y.value)),
											pc.Delay(y => ph.FirstOrDefaultAsync(x => y.value < x.value)))))
						.Distinct(x => x.value);
			})
			.Subscribe(x => Console.WriteLine($"{x.source}:{x.value}"));
