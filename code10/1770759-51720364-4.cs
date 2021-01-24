	public void LogIn(string usr, string pwd) 
	{	
		List<string> errors = new List<string>();
		
		if(string.IsNullOrEmpty(usr)) 
		{
			errors.Add("Username is empty.");
		}
	
		if(string.IsNullOrEmpty(pwd)) 
		{
			errors.Add("Password is empty.");
		}	
		
		if(errors.Count > 0) // If errors occur, throw exception.
        {
    	    throw new Exception(string.Join("\r\n",errors));
        }	
	}
 
