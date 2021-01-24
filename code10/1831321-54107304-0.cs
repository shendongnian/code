    private void delete_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(DataGridViewRow item in advancedDataGridView1.Rows)
            {
                if(bool.Parse(item.Cells[0].Value.ToString()))
                {
                    sb.AppendFormat("delete from tabl where id='{0}';{1}", item.Cells[1].Value, Environment.NewLine);
                    
                }
            }
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
            MessageBox.Show("Successfully Deleted....");
        }
