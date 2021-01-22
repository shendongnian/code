    public class Strategy
    {
    	private string _name = "default";
    	public string Name
    	{
      	     get { return _name; }
    		set { _name = value; }
    	}
    
    	public Strategy(string name)
   	{
  	        _name = name;
    	}
    }
