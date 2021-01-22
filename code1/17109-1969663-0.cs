    private bool CreateMode;
    private MyClass SomeClass;
    protected override void OnInit (EventArgs e)
    {
	    CreateMode = Session.GetSessionValue<bool> ("someKey1", () => true);
	    SomeClass = Session.GetSessionClass<MyClass> ("someKey2", () => new MyClass () 
        { 
           MyProperty = 123 
        });
    }
Here are the extension classes:
    public static class SessionExtensions    
    {
        public delegate object UponCreate ();
    	public static T GetSessionClass<T> (this HttpSessionState session, 
           string key, UponCreate uponCreate) where T : class
		{
			if (null == session[key])
			{
				var item = uponCreate () as T;
				session[key] = item;
				return item;
			}
			return session[key] as T;
		}
		public static T GetSessionValue<T> (this HttpSessionState session, 
           string key, UponCreate uponCreate) where T : struct
		{
			if (null == session[key])
			{
				var item = uponCreate();
				session[key] = item;
				return (T)item;
			}
			return (T)session[key];
		}
	}
