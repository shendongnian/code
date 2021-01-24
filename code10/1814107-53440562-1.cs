            private void Form1_Load(object sender, EventArgs e)
             {
                /*form load*/
                dataGridView1.Columns.Add("Column1", "qty");
                dataGridView1.Columns.Add("Column2", "price");
                
             }
            int RowIndex = 0;
            private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
            {
               
                if (e.KeyCode==Keys.Enter)
                {  /* .....
                    .....
                    ..... Sql connection*/
                    while (reader.Read()) {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[RowIndex].Cells[0].Value = reader.GetString(2);
                        dataGridView1.Rows[RowIndex].Cells[1].Value = reader.GetString(3);
                       
    
                        RowIndex++;
    
                    }
                    reader.Close();
    
                }
            }
