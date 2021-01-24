    Excel.Range testCell = ws.Cells[1, 3];
    testCell.WrapText = true;
    for (int row = 11; row < ws.UsedRange.Rows.Count; row += 2)
    {
        testCell.Value2 = ws.Cells[row, 4].Value2;
        testCell.Rows.AutoFit();
        ws.Range[string.Format("{0}:{1}", row, row + 1)].RowHeight = testCell.RowHeight / 2;
    }
