    	public class JobMappingOverride : IAutoMappingOverride<Job>
    	{
    	    	public void Override(AutoMapping<Job> mapping)
    	    	{
    	    	    	mapping.References(x => x.Group).Not.Nullable();
    	    	}
    	}
