    private void customSortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        int a = int.Parse(e.CellValue1.ToString()), b = int.Parse(e.CellValue2.ToString());
        // If the cell value is already an integer, just cast it instead of parsing
        e.SortResult = a.CompareTo(b);
        e.Handled = true;
    }
    ...
    yourGridview.SortCompare += customSortCompare;
    ...
