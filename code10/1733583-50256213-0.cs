    public class Foo
    {
    	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
    	public string Bar { get; set; }
    	public List<bool> Baz { get; set; }
    	
    	public Foo()
    	{
    		Bar = "Not Null";
    		Baz = new List<bool>
    		{
    			false
    		};
    	}
    }
