        var table = acc.GetTableReference("TableName");
        var partitionKey = "PartitionKey";
            
        TableQuery<TableModel> rangeQuery =
              new TableQuery<TableModel>()
              .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey.ToString()));
            var entities = table.ExecuteQuery(rangeQuery).ToList();
