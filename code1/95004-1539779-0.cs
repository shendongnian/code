    static readonly string[] FieldNames = new string[] { "CustomerID", "Name", "Address", ..., "Email" };
    using(SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString, options)) {
        bulkCopy.DestinationTableName = "Customers";
        //amount to bulkcopy at once to prevent slowing with large imports
        bulkCopy.BatchSize = 200;
        for(int i = 0; i < FieldNames.Length; i++) {
            bulkCopy.ColumnMappings.Add(
                new SqlBulkCopyColumnMapping(lstOutcome.Items[i].ToString(), FieldNames[i])
            );
        }
    }
