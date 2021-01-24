    public class Program
    {
    	public static void Main()
    	{
    		double value;
    		if(double.TryParse(Clipboard.GetText(), out value))
    		{
    			value *= 2; //change '2' to what ever you need it to be!
    			Clipboard.SetText(value.ToString());
    		}
    	}
    }
