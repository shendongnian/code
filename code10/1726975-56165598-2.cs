    public bool IsBusy { get; set; }
	protected async Task RunIsBusyTaskAsync(Func<Task> awaitableTask)
	{
		if (IsBusy)
		{
			// prevent accidental double-tap calls
			return;
		}
		IsBusy = true;
		try
		{
			await awaitableTask();
		}
		finally
		{
			IsBusy = false;
		}
	}
