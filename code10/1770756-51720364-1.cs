	public static List<string> LogIn(string usr, string pwd) 
	{	
		List<string> errors = new List<string>();
		
		if(usr == "") 
		{
			errors.Add("Username was empty.");
		}
	
		if(pwd== "") 
		{
			errors.Add("Password was empty.");
		}	
		
		return errors;	
	}
