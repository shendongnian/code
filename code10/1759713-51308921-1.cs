    public abstract class Test1
    {
    	[Ignore]
    	public decimal Extra { get; set; }
    }
    
    public class TestMap : ClassMap<Test>
    {
    	public TestMap()
    	{
    		AutoMap();
    	}
    }
