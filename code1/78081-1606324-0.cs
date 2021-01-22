    using System;
    
    using log4net.Core;
    
    namespace Test
    {
    	public class SmtpErrorHandler : IErrorHandler
    	{
    		public void Error(string message)
    		{
    			Logger.Log.Error(message);
    		}
    
    		public void Error(string message, Exception ex)
    		{
    			Logger.Log.Error(message, ex);
    		}
    
    		public void Error(string message, Exception ex, ErrorCode errorCode)
    		{
    			Logger.Log.Error(String.Format("{0}{1}Error code: {2}", message, Environment.NewLine, errorCode), ex);
    		}
    	}
    }
