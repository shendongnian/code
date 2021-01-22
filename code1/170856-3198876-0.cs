    public ArrayList GetSelectedRows(DataGrid datagrid)
    {
    ArrayList arrSelectedRows = new ArrayList();
    DataSet dset = (DataSet)datagrid.DataSource;
    for (int i=0; i<dset.Tables[0].Rows.Count; i++)
    {
    if (datagrid.IsSelected(i))
    {
    DataRow drow = dset.Tables[0].Rows[i];
    arrSelectedRows.Add(drow);
    }
    }
    return arrSelectedRows;
    }
