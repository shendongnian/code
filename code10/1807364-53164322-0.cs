    var filterOne = TableQuery.GenerateFilterCondition("PartitionKey" , QueryComparisons.Equal, "1");
    var filterTwo = TableQuery.GenerateFilterCondition("PartitionKey" , QueryComparisons.Equal, "2");
 
    var filterThree = TableQuery.GenerateFilterCondition("PartitionKey" , QueryComparisons.Equal, "3");
    var combinedFilters = TableQuery.CombineFilters(
                        TableQuery.CombineFilters(
                            filterOne,
                            TableOperators.Or,
                            filterTwo),
                        TableOperators.And, filter3);
    var query = new TableQuery<ConnectionEntity>()
        .Where(combinedFilters);
