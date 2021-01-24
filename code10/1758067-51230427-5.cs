     private void button4_Click(object sender, EventArgs e)
            {
                string location = @"C:\Users\lee\Lees Test File\testfile3.txt";
                StreamWriter myWriter = new StreamWriter(location, true);
    
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    { 
                    myWriter.Write(row.Cells[j].Value.ToString() + "|");
                    }
                }
                myWriter.Close();
                MessageBox.Show("File Saved!"); 
            }
