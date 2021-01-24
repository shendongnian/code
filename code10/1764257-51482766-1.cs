    HSSFCellStyle cellStyleBlue = (HSSFCellStyle)workbook.CreateCellStyle();
    cellStyleBlue.FillForegroundColor = IndexedColors.LightBlue.Index;
    cellStyleBlue.FillPattern = FillPattern.SolidForeground;
    for (int c = 0; c < headerRow.Cells.Count; c++)
    {
        headerRow.Cells[c].CellStyle = cellStyleBlue;
    }
