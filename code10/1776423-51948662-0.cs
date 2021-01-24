    private static Table NewTable(float[] paddings, float[] pointColumnWidths, float width, int rowStart, int rowEnd, float horizontalPosition, float verticalPosition, List<Cell> cells)
    {
        Table table = new Table(3);
        table.SetPaddings(paddings[0], paddings[1], paddings[2], paddings[3]);
        table.SetTotalWidth(pointColumnWidths);///this lined added
        foreach (Cell cell in cells)
            table.AddCell(cell);
        table.SetFixedPosition(horizontalPosition, verticalPosition, width);
        return table;
    }
