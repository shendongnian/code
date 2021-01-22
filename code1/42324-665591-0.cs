    protected override void OnError(EventArgs e) .....
    private void Application_Error(object sender, EventArgs e)
    {
    	if (GlobalHelper.IsMaxRequestExceededEexception(this.Server.GetLastError()))
    	{
    		this.Server.ClearError();
    		this.Server.Transfer("~/error/UploadTooLarge.aspx");
    	}
    }
