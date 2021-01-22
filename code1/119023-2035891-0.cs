    	public static bool IsEmailValid(string emailAddress)
		{
			Regex emailRegEx = new Regex(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b");
			if (emailRegEx.IsMatch(emailAddress))
			{
				return true;
			}
			return false;
		}
