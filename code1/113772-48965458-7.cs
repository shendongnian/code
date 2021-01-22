    public static class XConsole {
    	public static T BusyIndicator<T>(Func<T> action)
    	{
    		T result;
    
    		using (var spinner = new Spinner())
    		{
    			spinner.Start();
    
    			result = action();
    
    			spinner.Stop();
    		}
    
    		return result;
    	}
    
    	public static T BusyIndicator<T>(string content, Func<T> action)
    	{
    		T result;
    
    		using (var spinner = new Spinner())
    		{
    			spinner.Start(content);
    
    			result = action();
    
    			spinner.Stop();
    		}
    
    		return result;
    	}
    }
