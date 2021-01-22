    private void comboBox1_TextChanged(object sender, EventArgs e)
    {
        for(int i=0; i<comboBox1.Items.Count; i++)
        {
            if (comboBox1.Items[i].ToString().StartsWith(comboBox1.Text))
            {
                comboBox1.SelectedIndex = i;
                return;
            }
        }
    }
