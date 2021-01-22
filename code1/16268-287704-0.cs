    private void LogFormat(string message, params object[] args)
    {
    	if (this.BuildEngine != null)
    	{
    		this.Log.LogMessage(message, args);
    	}
    	else
    	{
    		Console.WriteLine(message, args);
    	}
    }
