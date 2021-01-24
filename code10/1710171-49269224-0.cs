    public class MySpecialFileAppender : log4net.Appender.RollingFileAppender
    {
    	protected void RenderLoggingEvent(TextWriter writer, LoggingEvent loggingEvent)
    	{
    		var rendered = RenderLoggingEvent(LoggingEvent loggingEvent);
    		var adjusted = AdjustText(rendered);
    		writer.Write(adjusted);		
    	}
    	
    	private string AdjustText(string inputText)
    	{
    		return "HELLO WORLD!!!";
    	}
    }
