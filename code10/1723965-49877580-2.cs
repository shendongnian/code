	private IList<CheckinPath> _changesMade = new List<CheckinPath>();
	public ICollectionView ChangesMadeView { get; private set; }
	public TestViewModel()
	{
		LoadData(); //Loads data for _changesMade
		ChangesMadeView = CollectionViewSource.GetDefaultView(_changesMade);
	}
	
	private bool _isChecked;
	public bool IsChecked
	{
		get { return _isChecked; }
		set
		{
			if (_isChecked != value)
			{
				_isChecked = value;
				RaisePropertyChanged(nameof(IsChecked));
				ChangesMadeView.Filter = checkinPath => { //do logic for filtering. Returns true or false ;};
				Messenger.Default.Send(new NotificationMessage("ResetColumnWidth"), TestWindow.Token); //notify the code behind of the view
			};
		}
	}
