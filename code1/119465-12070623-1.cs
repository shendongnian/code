    void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        var dgv = (DataGridView) sender
        string value1 = dgv.Rows[e.RowIndex1].Cells[e.Column.Index].FormattedValue.ToString();
        string value2 = dgv.Rows[e.RowIndex2].Cells[e.Column.Index].FormattedValue.ToString();
        
        e.SortResult = System.String.Compare(value1, value2);
        e.Handled = true;
    }
