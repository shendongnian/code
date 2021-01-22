    public class sbExtension
    {
    	[Extension()]
    	public void AppendFormattedLine(System.Text.StringBuilder oStr, string format, object arg0)
    	{
    		oStr.AppendFormat(format, arg0).Append(ControlChars.NewLine);
    	}
    	[Extension()]
    	public void AppendFormattedLine(System.Text.StringBuilder oStr, string format, object arg0, object arg1)
    	{
    		oStr.AppendFormat(format, arg0, arg1).Append(ControlChars.NewLine);
    	}
    	[Extension()]
    	public void AppendFormattedLine(System.Text.StringBuilder oStr, string format, object arg0, object arg1, object arg2)
    	{
    		oStr.AppendFormat(format, arg0, arg1, arg2).Append(ControlChars.NewLine);
    	}
    	[Extension()]
    	public void AppendFormattedLine(System.Text.StringBuilder oStr, string format, params object[] args)
    	{
    		oStr.AppendFormat(format, args).Append(ControlChars.NewLine);
    	}
    }
    
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Built and maintained by Todd Anglin and Telerik
    //=======================================================
