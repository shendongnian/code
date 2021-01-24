    protected void MakeStringColumnsRequired<T>(DbModelBuilder modelBuilder)
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
    
    protected  void MakeAllNullableColumnsRequired<T>(DbModelBuilder modelBuilder)
        where T : class
    {
        var type = typeof(T);
    	
        foreach (var prop in type.GetProperties()
    		.Where(x => Nullable.GetUnderlyingType(x.PropertyType) != null || x.PropertyType == typeof(string))
    		)
        {
            var argParam = Expression.Parameter(type, "x");
            var nameProperty = Expression.Property(argParam, prop.Name);
    
            var funcType = typeof(Func<,>);
            funcType = funcType.MakeGenericType(typeof(T), prop.PropertyType);
    
            var lambdaMethod = typeof(Expression).GetMethods(BindingFlags.Public | BindingFlags.Static)
    			.Where(x => x.Name == "Lambda" && x.IsGenericMethod).First();
            lambdaMethod = lambdaMethod.MakeGenericMethod(funcType);                
    
            var lambda = lambdaMethod.Invoke(null, new object[] { nameProperty, new ParameterExpression[] { argParam } });                
    
            var entity = modelBuilder.Entity<T>();
            var entityPropertyMethods = entity.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
    			.Where(x => x.Name == "Property" && !x.IsGenericMethod).ToList();                
    
            var entityPropertyMethod = entityPropertyMethods
    			.Where(x => x.GetParameters().First().ParameterType.GetGenericArguments().First().GetGenericArguments().Last() == prop.PropertyType)
    			.FirstOrDefault();
            if(entityPropertyMethod == null)
            {
                entityPropertyMethod = entity.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
    				.Where(x => x.Name == "Property" && x.IsGenericMethod).Last();
                entityPropertyMethod = entityPropertyMethod.MakeGenericMethod(Nullable.GetUnderlyingType(prop.PropertyType));
            }                
    
            var property = entityPropertyMethod.Invoke(entity, new object[] { lambda });
            var isRequired = property.GetType().GetMethod("IsRequired");
            isRequired.Invoke(property, null);                
        }
    }
        
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {        
    #if StringColumnsRequired
    	MakeStringColumnsRequired<Employee>(modelBuilder);
    #else
    	MakeAllNullableColumnsRequired<Employee>(modelBuilder)	
    #endif
    }
