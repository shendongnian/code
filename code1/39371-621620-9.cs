    public class MySession
    {
    	// private constructor
    	private MySession()
        {
          Property1 = "default value";
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
    	      session = new MySession();
    	      HttpContext.Current.Session["__MySession__"] = session;
    	    }
    	    return session;
    	  }
    	}
    
    	// **** add your session properties here, e.g like this:
    	public string Property1 { get; set; }
    	public DateTime MyDate { get; set; }
    	public int LoginId { get; set; }
    }
