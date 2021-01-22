        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch("[^0-9]", textBox1.Text))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }
