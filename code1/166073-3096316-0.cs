    public int LogOn(global::System.String UserName, global::System.String Password)
    {
    	ObjectParameter UserNameParameter;
    	if (UserName != null)
    	{
    		UserNameParameter = new ObjectParameter("USERNAME", UserName);
    	}
    	else
    	{
    		UserNameParameter = new ObjectParameter("USERNAME", typeof(global::System.String));
    	}
    
    	ObjectParameter UserpasswordParameter;
    	if (Password != null)
    	{
    		UserpasswordParameter = new ObjectParameter("USERPWD", Password);
    	}
    	else
    	{
    		UserpasswordParameter = new ObjectParameter("USERPWD", typeof(global::System.String));
    	}
    
    	return base.ExecuteFunction("LogOn", UserNameParameter, UserpasswordParameter);
    }
