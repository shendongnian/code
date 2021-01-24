    var nameSpace = "<the full namespace of your entity types here>";
    // Get the entity type:
    var entType = context.GetType().Assembly.GetType($"{nameSpace}.{entityTypeName}");
    // Get the MethodInfo of DbContext.Set<TEntity>():
    var setMethod = context.GetType().GetMethods().First(m => m.Name == "Set" && m.IsGenericMethod);
    // Now we have DbContext.Set<>(), turn it into DbContext.Set<TEntity>()
    var genset = setMethod.MakeGenericMethod(entType);
    // Create the DbSet:
    var dbSet = genset.Invoke(context, null);
    // Call the generic static method Enumerable.ToList<TEntity>() on it:
    var listMethod = typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(entType);
    var entityList = listMethod.Invoke(null, new[] { dbSet });
