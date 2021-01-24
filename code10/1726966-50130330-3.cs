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
