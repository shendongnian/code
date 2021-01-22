    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
                if (e.KeyChar!='\b')
                {
                  dataGridView1.Columns[0].Width += 5;  //the index or name of the column
                  
                }
                else
                {
                    dataGridView1.Columns[0].Width -= 5;  //for backspase pressing
                }
    }
