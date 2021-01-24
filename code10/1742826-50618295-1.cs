    var tables = context.GetType().GetProperties()
        .Where(x => 
            x.PropertyType.GenericTypeArguments
            .Any(y => typeof(IMyEnterface).IsAssignableFrom(y))
            );
    foreach (var table in tables)    
        if(sp_NotExecutedYet(table))
            context.Database
               .ExecuteSqlCommand($"EXEC sys.sp_addextendedproperty {propertyNameFor(table)}");
              
         
