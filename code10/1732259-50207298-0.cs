    DataTable table1 = new DataTable();
    table1.Columns.Add("MyId");
    table1.Columns.Add("Column1");
    table1.Columns.Add("Column2");
    DataTable table2 = new DataTable();
    table2.Columns.Add("Column3");
    table2.Columns.Add("MyId");
    table2.Columns.Add("Column4");
    DataTable table3 = new DataTable();
    table3.Columns.Add("Column5");
    table3.Columns.Add("MyId");
    table3.Columns.Add("Column6");
    
    foreach (DataRow drtable1 in table1.Rows)
    {
       foreach (DataRow drtable2 in table2.Rows)
        {
           if (Convert.ToString(drtable1["MyId"]) == Convert.ToString(drtable2["MyId"]))
                    {
                        table3.Rows.Add(drtable1["MyId"], drtable1["Column1"], drtable1["Column2"]);
                    }
        }
     }
