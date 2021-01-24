    DataTable productsAllColums = ....;
    DataTable productsJustColumnsToView = ...;
    bool columnOK;
    for (int i = productsAllColums.Columns.Count - 1; i >= 0; i--)
    {
        columnOK = false;
        for (int k = 0; k < productsJustColumnsToView.Columns.Count; k++)
        {
            if (productsAllColums.Columns[i].ColumnName == productsJustColumnsToView.Columns[k].ColumnName)
            {
                columnOK = true;
                break;
            }
        }
        if (!columnOK)
            productsAllColums.Columns.RemoveAt(i);
    }
