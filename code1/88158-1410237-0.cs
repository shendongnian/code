    grd.CellClick += new DataGridViewCellEventHandler(grd_CellClick);
    void grd_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == index_of_button_column)
        {
            MessageBox.Show(this, e.RowIndex.ToString() + " Clicked!");
            //...
        }
    }
