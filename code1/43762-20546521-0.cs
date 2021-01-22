    var columns = reader.GetSchemaTable().Rows
                                         .Cast<DataRow>()
                                         .Select(r => (string)r["ColumnName"])
                                         .ToList();
    //or
    var columns = Enumerable.Range(0, reader.FieldCount)
                            .Select(reader.GetName)
                            .ToList();
