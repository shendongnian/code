    void Main() {
        // test setup
        var term = "test";
    
    	var source = new [] {
    		new Status { Name = "some test" },
    		new Status { Name = "test other" },
    		new Status { Name = "other" }
    	}.AsQueryable();
    		
        // build expression 
    	// s => s.Name.Contains("{term}")
    	var paramExpr    = Expression.Parameter(typeof(Status), "s");
    	var nameExpr     = Expression.Property(paramExpr, nameof(Status.Name));
    	var termExpr     = Expression.Constant(term);
    	var containsExpr = Expression.Call(nameExpr, nameof(string.Contains), new Type[] { }, termExpr);
    	var lambda       = Expression.Lambda<Func<Status, bool>>(containsExpr, paramExpr);
    	
    	source.Where(lambda).Dump(); 
    }
    
    public class Status {
    	public string Name { get; set; }
    }
