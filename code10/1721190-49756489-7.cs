    Task tk = Task.Factory.StartNew(() =>
    	{
    		if (System.Threading.Monitor.TryEnter(_RefreshLocker))
    		{
    			try
    			{
    				VisualHelper.InvokeBackground(() =>
    				{
