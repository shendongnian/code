    private void Datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (!selectedRows.Exists(x =>x == index))
            {
               selectedRows.Add(index)
            }
        }
