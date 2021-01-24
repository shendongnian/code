    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        RadItem selectedItem = ComboBox1.SelectedItem as RadItem;
    
        if (selectedItem != null) {
            ComboBox1.Items.Remove(selectedItem);
            ComboBox1.Items.Sorted = true;
            ComboBox1.Items.Sorted = false;
            ComboBox1.Items.Insert(0, selectedItem);
            ComboBox1.Text = selectedItem.Text;
        }
    }
