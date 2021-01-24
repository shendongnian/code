	public static IObservable<T> When<T>(this IObservable<T> source, IObservable<bool> gate)
	{
		return
			source.Publish(ss => gate.Publish(gs =>
				gs
					.Select(g => g ? ss : ss.IgnoreElements())
					.Switch()
					.TakeUntil(Observable.Amb(
						ss.Select(s => true).Materialize().LastAsync(),
						gs.Materialize().LastAsync()))));
	}
