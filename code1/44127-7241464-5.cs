    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
                if (e.KeyChar!='\b')   //discard backspace
                {
                  dataGridView1.Columns[0].Width += 5;  //the column's index or name
                  
                }
                else
                {
                    dataGridView1.Columns[0].Width -= 5;  //for backspase pressing
                }
    }
