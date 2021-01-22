        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(comboBox1.Text)) { MessageBox.Show("YE"); }
            else { MessageBox.Show("NE"); }
            OR
            if (comboBox1.FindString(comboBox1.Text) > -1) { MessageBox.Show("YE"); }
            else { MessageBox.Show("NE"); }
        }
