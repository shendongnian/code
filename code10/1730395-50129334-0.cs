            bool bchange = false;
            private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (bchange == false)
                {
                    bchange = true;
                    String oritext = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    String newtext= oritext.First().ToString().ToUpper() + oritext.Substring (1);
                    //Update Database
    
                    //Update cell
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = newtext;
                 
                }
                else 
                {
                    bchange = false; 
                }
            }
