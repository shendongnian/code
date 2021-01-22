    iTotalColumns = xlWorkSheet.UsedRange.Columns.Count;
    iTotalRows = xlWorkSheet.UsedRange.Rows.Count;
    //These two lines do the magic.
    xlWorkSheet.Columns.ClearFormats();
    xlWorkSheet.Rows.ClearFormats();
    iTotalColumns = xlWorkSheet.UsedRange.Columns.Count;
    iTotalRows = xlWorkSheet.UsedRange.Rows.Count;
