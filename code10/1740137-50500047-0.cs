    var query = new TableQuery<EntityType>()
        .Where(
             TableQuery.CombineFilters(
                 TableQuery.GenerateFilterCondition("InstanceId", QueryComparisons.NotEqual, "a"), 
                 TableOperators.And,
                 TableQuery.GenerateFilterCondition("InstanceId", QueryComparisons.NotEqual, "b")
        ));
    //Or you can build the filter string directly
    var query = new TableQuery<EntityType>().Where("(InstanceId ne 'a') and (InstanceId ne 'b')");
