		_busyStackLifeTracker = new LifeTrackerStack
			(
				() =>
				{
					this.IsBusy = true;
				},
				() =>
				{
					this.IsBusy = false;
				}
			);
