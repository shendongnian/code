			Observable
				.FromEventPattern<
						System.Collections.Specialized.NotifyCollectionChangedEventHandler,
						System.Collections.Specialized.NotifyCollectionChangedEventArgs>(
					h => Rules.CollectionChanged += h,
					h => Rules.CollectionChanged -= h)
				.Select(ep => Rules.All(rule => rule.Check(Value)))
				.ObserveOn(Scheduler.Default)
				.Subscribe(b => IsValid = b);
