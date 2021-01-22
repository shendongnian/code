     DataTable table = new DataTable("table");
    DataColumn dc= table.Columns.Add("id", typeof(int));
            dc.AutoIncrement=true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
    // Add the column to a new DataTable.
   
    table.Columns.Add("name",typeof(string));
