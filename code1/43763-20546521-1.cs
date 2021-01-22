    var columns = reader.GetSchemaTable().Rows
                                         .Cast<DataRow>()
                                         .Select(r => (string)r["ColumnName"])
                                         .ToList();
    //Or
    var columns = Enumerable.Range(0, reader.FieldCount)
                            .Select(reader.GetName)
                            .ToList();
