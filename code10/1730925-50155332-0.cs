	IObservable<bool> checkBoxChecked = /* your checkbox observable here */
	IObservable<long> timer = Observable.Interval(TimeSpan.FromMilliseconds(200.0));
	
	IObservable<long> query =
		checkBoxChecked
			.Select(x => x ? timer : Observable.Never<long>().StartWith(-1L))
			.Switch();
			
	IDisposable subscription =
		query
			.Subscribe(n =>
			{
				if (n == -1L)
				{
					// Clear UI
				}
				else
				{
					// Update UI
				}
			});
