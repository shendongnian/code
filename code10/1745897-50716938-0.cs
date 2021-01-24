    private void textBox1_Enter(object sender, EventArgs e)
            {
                AcceptButton = button1;
            }
    
            private void textBox2_Enter(object sender, EventArgs e)
            {
                AcceptButton = button2;
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("First button clicked");
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Second button clicked ");
            }
