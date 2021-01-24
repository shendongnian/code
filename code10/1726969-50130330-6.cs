	private bool _areButtonsEnabled = true;
	public bool AreButtonsEnabled
	{
		get => _areButtonsEnabled;
		set
		{
			if (_areButtonsEnabled != value)
			{
				_areButtonsEnabled = value;
				OnPropertyChanged(nameof(AreButtonsEnabled)); // assuming your view model implements INotifyPropertyChanged
			}
		}
	}
	
	public ICommand Button1Command { get; protected set; }
	
	public MyViewModel()
	{
		Button1Command = new Command(HandleButton1Tapped);
	}
	
	private void HandleButton1Tapped()
	{
		// Run on the main thread, to make sure that it is getting/setting the proper value for AreButtonsEnabled
        // And note that calls to Device.BeginInvokeOnMainThread are queued, therefore
        // you can be assured that AreButtonsEnabled will be set to false by one button's command
        // before the value of AreButtonsEnabled is checked by another button's command.
        // (Assuming you don't change the value of AreButtonsEnabled on another thread)
		Device.BeginInvokeOnMainThread(() => 
		{
			if (AreButtonsEnabled)
			{
				AreButtonsEnabled = false;
				// button 1 code...
			}
		});
	}
	
	// don't forget to add Commands for Button 2 and 3
