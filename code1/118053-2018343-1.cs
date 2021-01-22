    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        if (e.Column.Index == 0)
        {
            if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
            {
                e.SortResult = 1;
            }
            else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
            {
                e.SortResult = -1;
            }             
            else
            {
                e.SortResult = 0;
            }
            e.Handled = true;
       }
    }
