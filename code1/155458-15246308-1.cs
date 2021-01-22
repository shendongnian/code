     DataTable table = new DataTable("table");
    DataColumn dc= table.Columns.Add("id", typeof(int));
            dc.AutoIncrement=true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
    // Add the new column name in DataTable
   
    table.Columns.Add("name",typeof(string));
        table.Rows.Add(null, "A");
        table.Rows.Add(null, "B");
        table.Rows.Add(null, "C");
