    DataTable table = new DataTable();
    table.Columns.Add("Foo",typeof(int));
    for (int i = 0; i < 10; i++)
        table.Rows.Add(i);
    
    for (int i = table.Rows.Count -1; i >=0; i--)
    {
        // sample removes all even foos
        if ((int)table.Rows[i]["Foo"] % 2 == 0)
            table.Rows.RemoveAt(i);
    }
