    private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {
        ComboBox2.DataSource = AlgorithmList
                 .Where(elm => elm != ComboBox1.GetItemText(ComboBox1.SelectedItem)).ToList();
    }
