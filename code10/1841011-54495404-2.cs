    private void DgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // exclude header
        {
            if (e.ColumnIndex == 0)
            {
                // edit action                    
            }
            else if (e.ColumnIndex == 1)
            {
                // delete action
                //dgvPeople.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
