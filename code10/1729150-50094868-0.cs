        private void DeleteData_Click(object sender, EventArgs e)
        {
            var rowsToDelete = dataGridView1.SelectedRows;
            using (SqlConnection sqcon = new SqlConnection(@"MY CONNECTION STRING"))
            {
                SqlCommand Scmd = new SqlCommand();
                Scmd.Connection = sqcon;
                sqcon.Open(); //ADDED   
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    try
                    {
                        Scmd.CommandText = "DELETE FROM Technican WHERE ID=" + row.Cells["Id"].Value.ToString() + "";
                        int count = Scmd.ExecuteNonQuery();
                        dataGridView1.Rows.Remove(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                sqcon.Close();
            }
        }
