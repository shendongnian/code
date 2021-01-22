    internal static class DataContextExtensions
    {
    	public static int ExecuteCommandEx(this DataContext context, string command, params object[] parameters)
    	{
    		if (context == null)
    			throw new ArgumentNullException("context");
    		if (parameters != null && parameters.Length > 0)
    			parameters = parameters.Select(p => p ?? "NULL").ToArray();
    		return context.ExecuteCommand(command, parameters);
    	}
    }
