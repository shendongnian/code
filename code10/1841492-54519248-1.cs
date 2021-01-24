    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        DataRow modifiedRow = ((DataTable)dataGridView1.DataSource).Rows[e.RowIndex];
        DataTable dt = (DataTable)dataGridView2.DataSource;
        //"Id" is name of the column that has unique, non-nullable values
        if (dt.Rows.OfType<DataRow>().Where(x => x["Id"].ToString() == modifiedRow["Id"].ToString()) != null)
        {
            dt.Rows.Remove(dt.Rows.OfType<DataRow>().Where(x => x["Id"].ToString() == modifiedRow["Id"].ToString()).ToList()[0]);
        }
        dt.Rows.Add(modifiedRow);
        dataGridView2.DataSource = dt;
    }
