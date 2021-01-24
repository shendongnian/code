    //table is a CloudTable object
    List<string> propertiesToRetrieve = new List<string>() { "MyIntProperty"}
    TableOperation op = TableOperation.Retrieve("partitionkey", "rowkey", propertiesToRetrieve);
    TableResult result = table.Execute(op);
	DynamicTableEntity myEntity = (DynamicTableEntity)result.Result;
	DateTime ts = myEntity.Timestamp;
    int? customIntProperty = myEntity.Properties["MyIntProperty"].Int32Value;
