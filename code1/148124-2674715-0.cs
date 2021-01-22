    private void customSortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        int a = int.Parse(e.CellValue1), b = int.Parse(e.CellValue2);
        // If the cell value is already an integer, just cast it instead of parsing
        e.SortResult = a < b ? -1 : (a > b ? 1 : 0);
        e.Handled = true;
    }
    ...
    yourGridview.SortCompare += customSortCompare;
    ...
