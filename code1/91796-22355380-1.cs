	public string Username { get; set; }
	public ICommand LoginCommand
	{
		get
		{
			return new RelayCommand<IWrappedParameter<string>>(password => { Login(Username, password); });
		}
	}
	private void Login(string username, string password)
	{
		// Perform login here...
	}
