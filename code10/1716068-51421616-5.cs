    // Iterate through all EF Entity types
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
    	#region Convert UniqueKeyAttribute on Entities to UniqueKey in DB
    	var properties = entityType.GetProperties();
    	if ((properties != null) && (properties.Any()))
    	{
    		foreach (var property in properties)
    		{
    			var uniqueKeys = GetUniqueKeyAttributes(entityType, property);
    			if (uniqueKeys != null)
    			{
    				foreach (var uniqueKey in uniqueKeys.Where(x => x.Order == 0))
    				{
    					// Single column Unique Key
    					if (String.IsNullOrWhiteSpace(uniqueKey.GroupId))
    					{
    						entityType.AddIndex(property).IsUnique = true;
    					}
    					// Multiple column Unique Key
    					else
    					{
    						var mutableProperties = new List<IMutableProperty>();
    						properties.ToList().ForEach(x =>
    						{
    							var uks = GetUniqueKeyAttributes(entityType, x);
    							if (uks != null)
    							{
    								foreach (var uk in uks)
    								{
    									if ((uk != null) && (uk.GroupId == uniqueKey.GroupId))
    									{
    										mutableProperties.Add(x);
    									}
    								}
    							}
    						});
    						entityType.AddIndex(mutableProperties).IsUnique = true;
    					}
    				}
    			}
    		}
    	}
    	#endregion Convert UniqueKeyAttribute on Entities to UniqueKey in DB
    }
