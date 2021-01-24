	public static class RxExtensions
	{
		public static IObservable<TResult> IntervalAsync<TResult>(Func<IObservable<TResult>> f, TimeSpan period)
		{
			return IntervalAsync(f, period, Scheduler.Default);
		}
		
		public static IObservable<TResult> IntervalAsync<TResult>(Func<IObservable<TResult>> f, TimeSpan period, IScheduler scheduler)
		{
			return Observable.Create<TResult>(o =>
			{
				var q = new BehaviorSubject<TimeSpan>(TimeSpan.Zero);
				var observable = q
					.Delay(t => Observable.Timer(t))
					.SelectMany(_ => f())
					.Do(t => q.OnNext(period));
				return observable.Subscribe(o);
			});
		}
	}
