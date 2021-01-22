    List<string> columns = new List<string>();
    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
    {
        DataTable dt = reader.GetSchemaTable();
        foreach (DataRow row in dt.Rows)
        {
            columns.Add(row.Field<String>("ColumnName"));
        }
    }
