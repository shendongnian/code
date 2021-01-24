    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
    
                string id = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
    
                string sqlQuery = string.Format("SELECT DocumentContent,DBName FROM myDatabase WHERE ID={0};", id);
    
                SqlDataAdapter myAdapter1 = new SqlDataAdapter(sqlQuery, myConnection);
                DataTable dt = new DataTable();
                myAdapter1.Fill(dt);
    
                foreach (DataRow row in dt.Rows)
                {
                    byte[] byteArray = (byte[])row["DocumentContent"];
                    string name = (string)row["DBName"];
                    File.WriteAllBytes("Path\\" + name, byteArray);
                }
    
            }
