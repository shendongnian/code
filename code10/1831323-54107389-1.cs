    private void delete_Click(object sender, EventArgs e)
    {
        List<string> selectedIds = new List<string>()
        foreach (DataGridViewRow item in advancedDataGridView1.Rows)
        {
            if (bool.Parse(item.Cells[0].Value.ToString()))
            {
                selectedIds.Add("'" + item.Cells[1].Value.ToString() + "'");
                // collecting all ids
            }
        }
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete from tabl where id in(@idsToDelete)", conn);
        cmd.Parameters.AddWithValue("@idsToDelete", string.Join(",", selectedIds);
        cmd.ExecuteNonQuery();
        conn.Close();
        MessageBox.Show("Successfully Deleted....");
    }
