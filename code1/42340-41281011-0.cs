    protected void Application_EndRequest(object sender, EventArgs e)
    {
    	//check for the "file is too big" exception if thrown at the IIS level
    	if (Response.StatusCode == 404 && Response.SubStatusCode == 13)
    	{
    		Response.Write("Too big a file"); //just an example
            Response.End();
    	}
    }
