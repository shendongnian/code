        private void Calculate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int diff = (Convert.ToInt32(textBox1.Text) - Convert.ToInt32(textBox2.Text));
                textBox3.Text = diff.ToString();
                if (diff >= 0)
                {
                    textBox3.ForeColor = Color.Green;
                }
                else
                    textBox3.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("PLZ Enter the balances");
            }
        }
