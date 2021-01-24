    using System.Data.Entity;
    using EntityFramework.DynamicFilters;
					
    public class Program
    {	
	    public class CustomContext : DbContext
    	{
	    	private int _tenantId;
		
		    public int GetTenantId()
    		{
	    		return _tenantId;
    		}
		
	    	// Call this function to set the tenant once authentication is complete.
		    // Alternatively, you could pass tenantId in when constructing CustomContext if you already know it
    		// or pass in a function that returns the tenant to the constructor and call it here.
	    	public void SetTenantId(int tenantId)
		    {
			    _tenantId = tenantId;
    		}
	    	
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
		    {
			    // Filter applies to any model that implements ITenantRestrictedObject
    			modelBuilder.Filter(
	    			"TenantFilter",
                    (ITenantRestrictedObject t, int tenantId) => t.TenantId == tenantId,
                    (CustomContext ctx) => ctx.GetTenantId(), // Might could replace this with a property accessor... I haven't tried it
                    opt => opt.ApplyToChildProperties(false)
			    );
		    }
	    }
	
    	public interface ITenantRestrictedObject
	    {
    		int TenantId { get; }
	    }
    }
