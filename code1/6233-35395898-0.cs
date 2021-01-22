     private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                  if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null && dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                   
                    SqlConnection conn = new SqlConnection("data source=.;initial catalog=pharmacy;integrated security=true");
                    SqlCommand cmd = new SqlCommand("select [drugTypeParent],[drugTypeChild] from [drugs] where [drugName]='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        
                        object[] o = new object[] { dr[0].ToString(),dr[1].ToString() };
                        DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1];
                       
                        dgvcbc.Items.Clear();
                        foreach (object itemToAdd in o)
                        {
                            dgvcbc.Items.Add(itemToAdd);
                        }
                    }
                    dr.Close();
                    conn.Close();
                   }
                }
