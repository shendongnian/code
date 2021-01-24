	public bool VerifyPassword(string storedPassword, string userPassword)
	{
		if(string.IsNullOrWhiteSpace(userPassword))
		{
			return false;
		}
	}
