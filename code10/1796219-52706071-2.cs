    List<int> colX = new List<int>();
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == 0)
        {
            if (e.ColumnIndex == -1) colX.Clear();  // assuming you have colum headers!
            colX.Add(e.CellBounds.X);
        }
    }
