    public class MyClass : Dictionary<int, string>
    {
    	public MyClass(Dictionary<int, string> dict)
    	{
    		foreach(var entry in dict)
    		{
    			this.Add(entry.Key, entry.Value);
    		}
    	}
    }
