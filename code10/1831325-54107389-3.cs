    private void delete_Click(object sender, EventArgs e)
    {
        List<string> selectedIds = new List<string>();
        foreach (DataGridViewRow item in advancedDataGridView1.Rows)
        {
            if (bool.Parse(item.Cells[0].Value.ToString()))
            {
                selectedIds.Add("'" + item.Cells[1].Value.ToString() + "'");
                // collecting all ids
            }
        }
        String sql = "delete from tabl where id in(@idsToDelete)";
        using (SqlConnection cn = new SqlConnection("Your connection string here")) 
        {
            using (SqlCommand cmd = new SqlCommand(sql, cn)) 
            {
                cmd.Parameters.Add("@idsToDelete", SqlDbType.VarChar).Value = string.Join(",", selectedIds);
                cmd.ExecuteNonQuery();
            }
        }      
    }
