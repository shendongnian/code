	private ICommand _Command;
	public ICommand Command
	{
		get { return (_Command = (_Command ?? new RelayCommand<MenuItemViewModel>(Execute))); }
	}
	public void Execute(MenuItemViewModel menuItem)
	{
		// ... do something here...
	}
