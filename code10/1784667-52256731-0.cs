    public class A_Mapper : ClassMap<A>
    {
    	public A_Mapper()
    	{
    		Map(a => a.field1).Index(1);
    		Map(a => a.field2).Index(0);
    	}
    }
