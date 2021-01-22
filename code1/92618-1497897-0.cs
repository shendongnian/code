    List<string> RowHeadings = new List<string>();
    string [,] Results = new string[MaxRows, 1]
    for (int Row = 0, SrcRow = 1; SrcRow <= MaxRows; Row++, SrcRow++) {
        if (ExcelData[SrcRow, 1] != null)
            RowHeadings.Add(ExcelData[SrcRow, 1]);
            ...
            ...
            Results[Row, 0] = ExcelData[SrcRow, 1];
    }
