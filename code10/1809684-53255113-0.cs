    public class A
    {
        protected int MyProtected { get; set; }
    	private int MyPrivate { get; set; }
    	
    	public class C : Collection<A>
    	{
    		public void Foo()
    		{
    			this[0].MyProtected++; // Allowed
    			this[0].MyPrivate++; // Also allowed!
    		}
    	}
    }
