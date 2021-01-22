        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "check text" &&
                textBox2.Text == "check another field" &&
                checkBox1.Checked)
            {
                //perform actions
            }
            else
            {
                MessageBox.Show("Your input failed validation.");
            }
        }
