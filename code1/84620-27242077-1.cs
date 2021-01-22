    DataTable table = new DataTable("Users");
    table.Columns.Add(new DataColumn()
    {
        ColumnName = "UserId",
        DataType = System.Type.GetType("System.Int32"),
        AutoIncrement = true,
        AllowDBNull = false,
        AutoIncrementSeed = 1,
        AutoIncrementStep = 1
    });
    table.Columns.Add(new DataColumn()
    {
        ColumnName = "UserName",
        DataType = System.Type.GetType("System.String"),
        AllowDBNull = true,
        DefaultValue = String.Empty,
        MaxLength = 50
    });
    table.Columns.Add(new DataColumn()
    {
        ColumnName = "LastUpdate",
        DataType = System.Type.GetType("System.DateTime"),
        AllowDBNull = false,
        DefaultValue = DateTime.Now, 
        Caption = "<defaultValue>GETDATE()</defaultValue>"
    });
    table.PrimaryKey = new DataColumn[] { table.Columns[0] };
    string sql = DataHelper.GetCreateTableSql(table);
    
    Console.WriteLine(sql);
