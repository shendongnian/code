        string _password;
		string Password
		{
			get { return _password; }
			set
			{
				// Validation logic.
				if (value.Length < 8)
				{
					throw new Exception("Password too short!");
				}
				_password = value;
			}
		}
