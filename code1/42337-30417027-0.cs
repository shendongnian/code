	//Global.asax
	private void Application_Error(object sender, EventArgs e)
	{
		var ex = Server.GetLastError();
		var httpException = ex as HttpException ?? ex.InnerException as HttpException;
		if(httpException == null) return;
		if(httpException.WebEventCode == WebEventCodes.RuntimeErrorPostTooLarge)
		{
			//handle the error
			Response.Write("Sorry, file is too big"); //show this message for instance
		}
	}
