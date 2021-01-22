        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(comboBox1.Text)) { MessageBox.Show("YE"); }
            else { MessageBox.Show("NE"); }
        }
