    public class Customers
    {
    
    	private int _CustomerID; 
    	private string _Fname;
    	private string _Lname;
    	private string _Country;
    	
        public Customers()    
    	{        
    		int CustomerID = 0;        
    		string Fname = string.Empty;        
    		string Lname = string.Empty;        
    		string Country = string.Empty;    
    	}    
    	
    	public int CustomerID    
    	{        
    		get { return _CustomerID; }        
    		set { _CustomerID = value; }    
    	}    
    	
    	public string Fname    
    	{        
    		get { return _Fname; }        
    		set { _Fname = value; }
    	}    
    	
    	public string Lname    
    	{        
    		get { return _Lname; }        
    		set { _Lname = value; }    
    	}    
    	
    	public string Country    
    	{        
    		get { return _Country; }        
    		set { _Country = value; }    
    	}
