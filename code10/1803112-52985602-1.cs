    int[] selectedRows = gridView4.GetSelectedRows();
    for (int i = 0; i < selectedRows.Length; i++)
    {
         // Get a DataRow and fill it with all values from the this selected row
         // This is where you went wrong, you kept using only the first selected row
         DataRow row = (gridView4.GetRow(selectedRows[i]) as DataRowView).Row;
         // Do your check for doubles here
         // Edit any values in row if needed
         row[2] = userShift.Text;
         row[3] = userShift.EditValue;
         row[4] = txtDate.EditValue;
         EmplDT.Rows.Add(row);
    }
