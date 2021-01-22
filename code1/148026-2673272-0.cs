    public interface ISomething
    {
    	int DoSomething(int someVar);
    }
    
    public class Something : ISomething
    {
    	private int someVar;
    	
    	public Something(int someVar)
    	{
    		this.someVar = someVar;
    	}
    	
    	public int DoSomething(int someVar)
    	{
    		return someVar + 1;
    	}
    }
    
    public class ParentClass
    {
       private int someVar;
    
       public ParentClass(ISomething something)
       {
           this.someVar = something.DoSomething(someVar);
       }
    }
    
    public class ChildClass : ParentClass
    {
        public ChildClass(int someVar) : base(new Something(someVar))
        {
            
        }
    }
