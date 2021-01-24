    private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill all the textbox correctly!");
            }
            else
            {
                MessageBox.Show("Not empty");
            }
        }
