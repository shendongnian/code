    SqlParameter CreateIdentifierTableParameter(string name, IEnumerable<int> identifiers)
    {
        // Build a DataTable whose schema matches that of our custom table type.
    	var identifierTable = new DataTable(name);
        identifierTable.Columns.Add("Identifier", typeof(long));
        foreach (var identifier in identifiers)
            identifierTable.Rows.Add(identifier);
            
        return new SqlParameter
        {
            ParameterName = name,              // The name of the parameter in the query to be run.
            TypeName = "dbo.IdentifierList",   // The name of our table type.
            SqlDbType = SqlDbType.Structured,  // Indicates a table-valued parameter.
            Value = identifierTable,           // The table created above.
        };
    }
