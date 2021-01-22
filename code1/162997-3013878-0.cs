    class Program
    {
    	static void Main(string[] args)
    	{
    	    string sample = "John Doe        New York  Test Comment";
    	    MyClass c = sample;
    	}
    }
    	
    public class MyClass
    {
    	public string Name;
    	public string Address;
    	public string Comment;
    		
    	public MyClass(string value)
    	{
    		//parsing of value and assigning to Name, Adress, Comment comes here
    	}
    		
    	public static implicit operator MyClass(string value)
    	{
    		return new MyClass(value);
    	}
    }
