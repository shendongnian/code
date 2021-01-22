    public class MySession
    {
    	// private constructor
    	private MySession() 
    	{
    	}
     
    	// Gets the current session.
    	public static MySession Current
    	{
    	  get
    	  {
    	    MySession session =
    	      (MySession)HttpContext.Current.Session["__MySession__"];
    	    if (session == null)
    	    {
    	      session = new AuiSession();
    	      HttpContext.Current.Session["__MySession__"] = session;
    	    }
    	    return session;
    	  }
    	}
    
    	// my session property 1 
    	public string Property1 { get; set; }
    
    	// my session property 2 
    	public DateTime Property2 { get; set; }
    	
    	// login id
    	public int LoginId { get; set; }
    }
