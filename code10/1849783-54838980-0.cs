    private void Form2_Load(object sender, EventArgs e)
        {
            button1.Hide();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex!=-1&&listBox1.SelectedIndex>0)
            {
                button1.Show();
            }
            else
            {
                button1.Hide();
            }
        }
