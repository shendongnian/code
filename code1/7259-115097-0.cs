    If mTable.Rows.Count = 1 AndAlso mTable.Rows(0)(<first column to check for null value>) Is DBNull.Value AndAlso mTable.Rows(0)(<second column>) Is DBNull.Value AndAlso mTable.Rows(0)(<thrid column>) Is DBNull.Value Then  
    mTable.Rows.Remove(mTable.Rows(0))  
    End If
    mTable.Rows.Add(row)
    gridView.Datasource = mTable
    gridView.Databind()
