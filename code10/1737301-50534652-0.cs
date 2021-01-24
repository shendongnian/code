    using(var conn = new SqlConnection("YourConnectionString"))
    {
        var bulkCopy = new SqlBulkCopy(conn)
					    {
						DestinationTableName =
							$"[YourSchemaName].[{YourTableName}]"
					    };
	    bulkCopy.WriteToServer(((DataView) yourDataGrid.ItemsSource).Table);
    }
