    var query = new TableQuery<EntityType>()
        .Where(
            TableQuery.CombineFilters(
                TableQuery.GenerateFilterConditionForInt("InstanceId", QueryComparisons.NotEqual, a), 
                TableOperators.And, 
                TableQuery.GenerateFilterConditionForInt("InstanceId", QueryComparisons.NotEqual, b)
        ));
    //Or build the filter string directly
    var query = new TableQuery<EntityType>().Where("(InstanceId ne a) and (InstanceId ne b)");
