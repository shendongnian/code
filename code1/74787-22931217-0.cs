    protected void myDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        int i = 0;
        string colName;
    
        foreach (TableCell cell in e.Item.Cells)
        {
            //string cellTxt = e.Item.Cells[i].Text;
            DataRowView dv = (DataRowView)e.Item.DataItem;
            colName = dv.DataView.Table.Columns[i].ColumnName;
            i++;
        }
    }
