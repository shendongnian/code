    protected void MakeColumnsRequired<T>(DbModelBuilder modelBuilder)
    	where T : class
    {
    	var type = typeof(T);
    	foreach (var prop in type.GetProperties().Where(x => x.PropertyType == typeof(string)))
    	{
    		var argParam = Expression.Parameter(type, "x");
    		var nameProperty = Expression.Property(argParam, prop.Name);
    		var lambda = Expression.Lambda<Func<T, string>>(nameProperty, argParam);
    		modelBuilder.Entity<T>().Property(lambda).IsRequired();
    	}            
    }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {        
        //another code...
    	MakeColumnsRequired<Employee>(modelBuilder);
    }
