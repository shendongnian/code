    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        DataTable dt = new DataTable();
        if (dataGridView1.DataSource != null)
        {
            dt = (DataTable)dataGridView1.DataSource;
            if (dt.Rows.Count > 0)
            {
                DataRow modifiedRow = dt.Rows[e.RowIndex];
    
                if (dataGridView2.DataSource != null)
                {
                    dt = (DataTable)dataGridView2.DataSource;
                    //"Id" is name of the column that has unique, non-nullable values
                    if (dt.Rows.Count > 0 && dt.Rows.OfType<DataRow>().Where(x => x["Id"].ToString() == modifiedRow["Id"].ToString()) != null)
                    {
                        dt.Rows.Remove(dt.Rows.OfType<DataRow>().Where(x => x["Id"].ToString() == modifiedRow["Id"].ToString()).ToList()[0]);
                    }
                }
                else
                {
                    dt = new DataTable();
                }
                dt.Rows.Add(modifiedRow);
            }
        }
        dataGridView2.DataSource = dt;
    }
