    private void comboBox1_MouseEnter(object sender, EventArgs e)
    {
        comboBox1.Items.Clear();
        for (int i = 0; i < options.Count(); i++)
        {
            comboBox1.Items.Add(options[i]);
        }
    }
