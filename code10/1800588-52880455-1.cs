    for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows.Rows[i].Cells[j].Value != null)
                        {
                               foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[0].Value.ToString().Contains(searchstring))
                                    {
                                         //Do something   
                                    }
                                }
    
                        }
    
                    }
    
                }
