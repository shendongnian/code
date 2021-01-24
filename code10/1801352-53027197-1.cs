    class Program
    {
    	static void Main()
    	{
    		var foo = new Foo
    		{
    			Bar =
    			{
    				"one",
    				"two"
    			}
    		};
    	}
    }
    
    public class Foo
    {
    	public List<string> Bar { get; set; } = new List<string>();
    }
