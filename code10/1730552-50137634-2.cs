	public static IObservable<T> Retry<T>(this GenericRetryExecutorRequest<T> request)
	{
		return Observable.Timer(Timespan.Zero, request.Interval)
			.Select(item =>
			{
				try
				{
					var value = request.GenericRetryActions.OnExecute();
					return Notification.CreateOnNext(value);
				}
				catch(Exception e)
				{
					request.GenericRetryActions.OnCatch();
					return Notification.CreateOnError<T>(e);
				}
			})
			.Dematerialize()
			.Retry(request.RetryCount);
	}
