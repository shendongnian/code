	public RelayCommand<object> SignIn
	{
		get
		{
			if (this.signIn == null)
			{
				this.signIn = new RelayCommand<object>((passwordContainer) => 
					{
						var password = passwordContainer.GetType().GetProperty("Password").GetValue(passwordContainer) as string;
						this.authenticationService.Authenticate(this.Login, password);
					});
			}
			return this.signIn;
		}
	}
