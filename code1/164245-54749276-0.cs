    private const int GridAutoResizeBoundary = 100;
    private const int MaxColumnWidth = 300;
    public static void AutoSizeColumns(this DataGridView dataGridView)
    {
        if (dataGridView.RowCount <= GridAutoResizeBoundary)
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        else
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {
            if (column.Width > MaxColumnWidth)
                column.Width = MaxColumnWidth;
        }
    }
