    public static class Extensions
    {
    	public static void AppendLine(this StringBuilder builder,string format, params object[] args)
    	{
    		builder.AppendLine(string.Format(format, args));
    	}
    }
