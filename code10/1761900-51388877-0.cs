    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string YourItem = comboBox1.Text;
        //If you only want to add selected item
        DataGridView.Add(YourItem);
        //or add all
        foreach (string str in LstProductos)
        {
               DataGridView.Rows.Add(str);
        }
    }
