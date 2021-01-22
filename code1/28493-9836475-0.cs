    System.Data.DataTable dtNew = new DataTable();
    for (int iCol = 0; iCol < dtOriginalData.Columns.Count; iCol++)
    {
        dtNew.Columns.Add(dtOriginalData.Columns[iCol].ColumnName, dtOriginalData.Columns[iCol].DataType);
    }
    for (int iCopyIndex = 0; iCopyIndex < item.Data.Rows.Count; iCopyIndex++)
    {
        dtNew.Rows.Add(dtOriginalData.Rows[iCopyIndex].ItemArray);
        //dtNew.ImportRow(dtOriginalData.Rows[iCopyIndex]); 
    }
    dtOriginalData = dtNew; 
