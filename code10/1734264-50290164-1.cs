    for (CellRangeEnumerator enumerator = workSheet.Cells.GetReadEnumerator(); enumerator.MoveNext(); )
    {
        ExcelCell cell = enumerator.Current;
        var value = cell.Value;
        // ...
    }
