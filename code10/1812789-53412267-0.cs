    private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewRow row = dataGridView1.SelectedRows[0]; //Selecting only first selected row.
        //Above code of getting row will not work if you have not set datagridview mode to full selection.
        //If you do not want to you could get row like this
         DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
         int CategoryIdOfSelectedOne = Convert.ToInt32(row["CategoryID"].Value);
         (secondDGV.DataSource as DataTable).DefaultView.RowFilter = string.Format("CategoryID= '{0}'", CategoryIdOfSelectedOne);
    }
