    for (int c = 0; c < headerRow.Cells.Count; c++)
    {
        headerRow.Cells[0].CellStyle.FillForegroundColor= IndexedColors.LightBlue.Index;
        headerRow.Cells[0].CellStyle.FillPattern = FillPattern.SolidForeground;
    }
