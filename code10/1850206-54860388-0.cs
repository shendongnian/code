    private void textBox1_TextChanged(object sender, EventArgs e)
            {
                int a;
                bool isNumeric = int.TryParse(textBox1.Text, out a);
                if (isNumeric)
                {
                    MessageBox.Show("Something went wrong");
                }
            }
