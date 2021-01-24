    ComboboxItem comboItem = new ComboboxItem();
    item2.Text = "Admin";
    item2.Value = "Admin";
    
    ComboboxItem comboItem2 = new ComboboxItem();
    item2.Text = "Employee";
    item2.Value = "Employee";
    
    List<ComboboxItem> items = new List<ComboboxItem> { comboItem, comboItem2 };
    
    this.yourComboBox.DisplayMember = "Text";
    this.yourComboBox.ValueMember = "Value";
    this.comboBox1.DataSource = items;
    class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
