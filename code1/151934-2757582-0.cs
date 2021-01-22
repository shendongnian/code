    If(finalTable.Columns.CanRemove(finalTable.Columns[0]))
    {
        finalTable.Columns.RemoveAt(0); 
    }
    finalTable.AcceptChanges()
