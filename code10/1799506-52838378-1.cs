    var type = (Type)(this.comboBoxTables.SelectedItem as ComboBoxItem).Value;
    object[] result = this.DataLoader.Get(type);
    
    dataGridView1.DataSource = result;
    //this.dataGridView1.Columns.Clear();
    
    var properties = type.GetProperties();
    
    List<Shell> shells = new List<Shell>();
    foreach (var item in properties)
    {
        shells.Add(new Shell(item.Name));
    }
    
    foreach (var property in shells)
    {
        this.dataGridView1.Columns.Add(property.Name, property.Name);
        this.dataGridView1.Columns[property.Name].DataPropertyName = property.Name;
    }
    
    this.dataGridView1.Refresh();
