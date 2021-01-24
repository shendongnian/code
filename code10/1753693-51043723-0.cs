    // initialize the connection
    using (SqlConnection con = new SqlConnection(metadata.DatabaseString))
    {
        // open the connection
        con.Open();
        // initialize a new SqlCommand to get the schema. 0 = 1 ensures an empty data set
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM " + metadata.TableName + " WHERE 0=1", con);
        // GetSchemaTable() gets the table's metadata
        DataTable dataTable = new DataTable();
        // tell the adapater to fill in the missing schema
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        // fill the datatable with the schema
        adapter.FillSchema(dataTable, SchemaType.Mapped);
        // loops through all the rows of the data table
        foreach (DataColumn column in dataTable.Columns)
        {
            // field names found here: https://msdn.microsoft.com/en-us/library/system.data.datatablereader.getschematable(v=vs.110).aspx#Remarks
            metadata.ColumnMetadata.Add(new ColumnWrapper()
            {
                ColumnType = column.DataType,
                ColumnName = column.ColumnName,
                ByteSize = column.MaxLength,
                IsKey = dataTable.PrimaryKey.Contains(column)
            });
        }
    }
