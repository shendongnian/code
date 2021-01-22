    private void RefreshRawData(string dataSource, string connection)
    {
        xl._Worksheet ws = (xl._Worksheet)xlTemplate.Worksheets["Raw Data"];
        xl.ListObject table = ws.ListObjects["Table_ExternalData_1"];
        xl.QueryTable qt = table.QueryTable;
        string connStr = GetExcelConnectionString((string)qt.Connection);
        table.Delete();
        xl.Range r = ws.get_Range("A1", "A1");
        table = ws.ListObjects.Add(xl.XlListObjectSourceType.xlSrcExternal, (object)connStr, m, xl.XlYesNoGuess.xlGuess, r);
        qt = table.QueryTable;
        qt.CommandType = xl.XlCmdType.xlCmdSql;
        qt.CommandText = dataSource;
        qt.RowNumbers = false;
        qt.FillAdjacentFormulas = false;
        qt.PreserveFormatting = true;
        qt.RefreshOnFileOpen = false;
        qt.BackgroundQuery = true;
        qt.RefreshStyle = xl.XlCellInsertionMode.xlInsertDeleteCells;
        qt.SavePassword = false;
        qt.SaveData = true;
        qt.AdjustColumnWidth = true;
        qt.RefreshPeriod = 0;
        qt.PreserveColumnInfo = true;
        qt.ListObject.DisplayName = "Table_ExternalData_1";
        qt.Refresh(false);
        Marshal.ReleaseComObject(ws);
        Marshal.ReleaseComObject(table);
        Marshal.ReleaseComObject(qt);
        ws = null;
        table = null;
        qt = null;
    }
