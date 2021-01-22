    void doTableStuff()
    {
        DataTable table1 = makeTable();
        table1.Rows.Add(new string[] { "Frederic", "Robert" });
        table1 = updateTable(table1);
        if (table1.Rows[0]["Sam"] == "Samantha")
        {
            Console.WriteLine("I Was Right!");
        }
        else
        {
            Console.WriteLine("I Was Wrong!");
        }
                
    }
    DataTable makeTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn { ColumnName = "Fred", DataType = typeof(string), DefaultValue = "fred" });
        dt.Columns.Add(new DataColumn { ColumnName = "Bob", DataType = typeof(string), DefaultValue = "bob" });
        return dt;
    }
    DataTable updateTable(DataTable oldTable)
    {
        DataTable newTable = makeTable();
        newTable.Columns.Add(new DataColumn { ColumnName = "Sam", DataType = typeof(string), DefaultValue = "Samantha" });
        newTable.Merge(oldTable, true, MissingSchemaAction.Add);
        return newTable;
    }
