    this.dataGridView1.CellContentClick += _
        new Forms.DataGridViewCellEventHandler(this.CellContentClick);
    private void CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        //make sure click not on header and column is type of ButtonColumn
        if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() ==  _
                               typeof(DataGridViewButtonColumn))
        {
             //TODO - Execute Code Here
        }
    }
