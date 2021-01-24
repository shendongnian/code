    private DataGridCellInfo _currentCell;
    public DataGridCellInfo CurrentCell
    {
        get { return _currentCell; }
        set { _currentCell = value; OnCurrentCellChanged(); }
    }
    void OnCurrentCellChanged()
    {
        DataGridCell Cell = GetCurrentDataGridCell(_currentCell);
        var Position = Cell.PointToScreen(new Point(0, 0));
        TextBlock text = (TextBlock)Cell.Content;
        MessageBox.Show("Value=" + text.Text, "Position");
    }
    public static DataGridCell GetCurrentDataGridCell(DataGridCellInfo cellInfo)
    {
        if (cellInfo == null || cellInfo.IsValid == false)
        {
            return null;
        }
        var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
        if (cellContent == null)
        {
            return null;
        }
        return cellContent.Parent as DataGridCell;
    }
