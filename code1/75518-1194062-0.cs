    private void dataGridView1_SortCompare(object sender,
            DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue2.ToString(), e.CellValue1.ToString()); // descending sort
            
            e.Handled = true;
        }
