    private DataTable MakeTableWithAutoIncrement()
    {
        // Make a table with one AutoIncrement column.
        DataTable table = new DataTable("table");
        DataColumn idColumn = new DataColumn("id", 
            Type.GetType("System.Int32"));
        idColumn.AutoIncrement = true;
        idColumn.AutoIncrementSeed = 10;
        table.Columns.Add(idColumn);
    
        DataColumn firstNameColumn = new DataColumn("Item", 
            Type.GetType("System.String"));
        table.Columns.Add(firstNameColumn);
        return table;
    }
