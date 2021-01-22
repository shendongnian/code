    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnection))
            {
                bulkCopy.ColumnMappings.Add("ID", "ID");
                bulkCopy.ColumnMappings.Add("Email", "Email");
                bulkCopy.DestinationTableName = "tableName";
                bulkCopy.WriteToServer(ExcelReader);
            }
