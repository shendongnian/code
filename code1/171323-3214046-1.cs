	public static IObservable<T> ThrottleResponsive3<T>(this IObservable<T> source, TimeSpan minInterval)
	{
		return Observable.CreateWithDisposable<T>(o =>
		{
			object gate = new Object();
			Notification<T> last = null, lastNonTerminal = null;
			DateTime referenceTime = DateTime.UtcNow - minInterval;
			var delayedReplay = new MutableDisposable();
			return new CompositeDisposable(source.Materialize().Subscribe(x =>
			{
				lock (gate)
				{
					var elapsed = DateTime.UtcNow - referenceTime;
					if (elapsed >= minInterval && delayedReplay.Disposable == null)
					{
						referenceTime = DateTime.UtcNow;
						x.Accept(o);
					}
					else
					{
						if (x.Kind == NotificationKind.OnNext)
							lastNonTerminal = x;
						last = x;
						if (delayedReplay.Disposable == null)
						{
							delayedReplay.Disposable = Scheduler.ThreadPool.Schedule(() =>
							{
								lock (gate)
								{
									referenceTime = DateTime.UtcNow;
									if (lastNonTerminal != null && lastNonTerminal != last)
										lastNonTerminal.Accept(o);
									last.Accept(o);
									last = lastNonTerminal = null;
									delayedReplay.Disposable = null;
								}
							}, minInterval - elapsed);
						}
					}
				}
			}), delayedReplay);
		});
	}
