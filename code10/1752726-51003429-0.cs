    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Your connection string");
        conn.Open();
        //Thinking that the first cell in every row contains the primary key, it will get the primary key from the first selected row
        string key = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        SqlCommand cmd = new SqlCommand("delete from YourTableName where id = " + key, conn);
        cmd.ExecuteNonQuery();
        //Get the index of the selected row and delete it from the rows
        int indexOfSelectedRow = dataGridView1.SelectedRows[0].Index;
        dataGridView1.Rows.RemoveAt(indexOfSelectedRow);
    }
