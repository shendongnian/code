    class Program
    {
    	static void Main(string[] args)
    	{
    		string json = "{\"error_count\":1,\"errors\":[{\"email_address\":\"blablagmail.com\",\"error\":\"Please provide a valid email address.\"}]}";
    
    		MailChimpResponse obj = new JavaScriptSerializer().Deserialize<MailChimpResponse>(json);
    
    		if (obj != null && obj.error_count > 0 && obj.errors!=null)
    		{
    			string errorString = "";
    
    			foreach (var error in obj.errors)
    			{
    				var casting = (Dictionary<string,object>)error;
    
    				errorString = string.Join(",", casting.Select(x => x.Key + ":" + x.Value).ToArray());
    			}
    
    			Console.WriteLine(errorString);
    		}
    
    		Console.ReadLine();
    	}
    }
    
    public class MailChimpResponse
    {
    	public object[] new_members { get; set; }
    	public object[] updated_members { get; set; }
    	public object[] errors { get; set; }
    	public int total_created { get; set; }
    	public int total_updated { get; set; }
    	public int error_count { get; set; }
    }
