    for (int dtCol = dt.Columns.Count - 1; dt > 10; dtCol--)
    {
        //ExceptedLastColName is name of last col in my code
        if (dt.Columns[dtCol].ColumnName == "ExceptedLastColName")
        {
            continue;
        }
        else
        {
            dt.Columns.RemoveAt(dtCol);
        }
    }
