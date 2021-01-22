    private static readonly object _comBoxSyncObj = new object();
    public void LogComText(string comText, bool newline)
    {
    	if (comBox.InvokeRequired)
    	{
    		comBox.Invoke(new Action(delegate
    		{
    			LogComText(comText, newline);
    		}));
    		return;
    	}
    	lock (_comBoxSyncObj)
    	{
    		comBox.AppendText(comText);
    		if(newline) comBox.AppendText(Environment.NewLine);
    	}
    }
