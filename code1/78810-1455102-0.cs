    [WebMethod]
    	[SoapHeader("authentication")]
    	public User Authenticate()
    	{
    		try
    		{
    			authentication.Roles = new string[] { UserRoles.Users };
    			ConfigureAuthentication();
    			Service<ISecurity>.Interface.Authenticate();
    			Guid userId = Service<ISecurity>.Interface.GetUserId(authentication.UserName);
    			return Service<IObjectRetriever>.Interface.Retrieve<User>(userId);
    		}
    		catch (Exception ex)
    		{
    			WriteException(ex);
    			throw new SoapException(ex.Message, new XmlQualifiedName(SoapException.ServerFaultCode.Name), ex);
    		}
    	}
