    var ctx = new YourDataContext();
    var tables = ctx.Mapping.MappingSource.GetModel(ctx.GetType()).GetTables();
    foreach (var table in tables)
    {
       // table.TableName
    }
