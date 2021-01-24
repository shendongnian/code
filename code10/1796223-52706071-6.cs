    List<int> colX = new List<int>();
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == 0)
        {
            if (e.ColumnIndex == (dataGridView1.RowHeadersVisible ?  -1 : 0)) colX.Clear();
            colX.Add(e.CellBounds.X);
        }
    }
