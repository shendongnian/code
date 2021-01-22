    DataTable tbl = new DataTable("Items");
    tbl.Columns.Add("Name");
    
    DataRow row = tbl.NewRow();
    row["Name"] = "Fruits";
    tbl.Rows.Add(row);
    
    DataRow row2 = tbl.NewRow();
    row2["Name"] = "Vegetables"; // original code has "row" here
    tbl.Rows.Add(row2);
    
    DataRow row3 = tbl.NewRow();
    row3["Name"] = "Meats";
    tbl.Rows.Add(row3);
    
    DataRow row4 = tbl.NewRow();
    row4["Name"] = "Drinks";
    tbl.Rows.Add(row4);
    
    DataRow row5 = tbl.NewRow();
    row5["Name"] = "Bread";
    tbl.Rows.Add(row5);
    
    //ItemList.ItemsSource = tbl.Select();
    ItemList.ItemsSource = new DataView(tbl);
