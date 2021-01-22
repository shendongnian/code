    private void Test()
    {
        ComboboxItem item = new ComboboxItem();
        item.Text = "Item text1";
        item.Value = 12;
        comboBox1.Items.Add(item);
        comboBox1.SelectedIndex = 0;
        MessageBox.Show((comboBox1.SelectedItem as ComboboxItem).Value.ToString());
    }
