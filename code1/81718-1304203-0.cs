    class MyObject
    {
    	public class Builder
    	{
    		public Builder()
    		{
    			// set default values
    			Name = String.Empty;
    		}
    		
    		public MyObject Build()
    		{
    			return new MyObject(Name);
    		}
    		public string Name { get; set; }
    	}
    	
    	private static int nextId;
    
    	protected MyObject(string name)
    	{
    		Id = ++nextId;
    		Name = name;
    	}
    	
    	public int Id { get; private set; }
    	public string Name { get; private set; }
    }
