    List<DatabaseStructure> input = ...
    
    List<Table> tables = input
        .GroupBy( dbs => new { dbs.TableSchema, dbs.TableName } )
        .Select( grp => new Table()
        {
            Name = grp.Key.TableName,
            Schema = grp.Key.TableSchema,
            Columns = grp
                .Select( col => new Column()
                {
                    Name = col.Name,
                    IsPrimaryKey = col.IsPrimaryKey
                } )
                .ToList()
        } )
        .ToList()
