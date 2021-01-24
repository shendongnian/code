    public ViewModel()
    {
    	try
    	{
    		Messenger.Default.Register<NotificationViewModelRefresh>(this, HandleRefreshAction);
    	}
    	catch (Exception error)
    	{
    		BusinessLogger.Manage(error);
    	}
    }
    
    private void HandleRefreshAction(NotificationViewModelRefresh msg)
    {
    	if (!this.IsVisible)
    		return;
		 
