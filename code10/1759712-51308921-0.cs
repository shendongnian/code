    public class TestMap : ClassMap<Test>
    {
    	public TestMap()
    	{
    		Map(m => m.Id);
    		Map(m => m.Name);
    	}
    }
