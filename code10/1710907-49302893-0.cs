    public class Example
    {
    	public static void Main()
    	{
    		Regex regex = new Regex(@"^[a-z\d](?:[a-z\d_-]*[a-z\d])?$");
    		string[] strings = {"my-new_page", "pagename", "-my-new-page", "my-new-page_", "!@#$%^&*()"};
            	
    		foreach(string s in strings) {
            		if (regex.IsMatch(s))
            		{
            			Console.WriteLine(s);
            		}
    		}
    	}
    }
