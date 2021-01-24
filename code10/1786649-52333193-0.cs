    public class EditorialDateFormat
    {
    	private string _en;
    
    	public string en
    	{
    		get { return !string.IsNullOrEmpty(_en) ? _en : fr; }
    		set { _en = value; }
    	}
    	private string _fr;
    
    	public string fr
    	{
    		get { return !string.IsNullOrEmpty(_fr) ? fr : Default; }
    		set { _en = value; }
    	}
    
    	public string Default { get; set; }
    }
    
