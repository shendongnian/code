    DataTable dataTable = new DataTable();
    dataTable = OldDataTable.Tables[0].Clone();
    foreach(DataRow dr in RowData.Tables[0].Rows)
    {
     DataRow AddNewRow = dataTable.AddNewRow();
     AddNewRow.ItemArray = dr.ItemArray;
     dataTable.Rows.Add(AddNewRow);
    }
