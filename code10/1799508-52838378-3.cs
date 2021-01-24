    var type = (Type)(this.comboBoxTables.SelectedItem as ComboBoxItem).Value;
    object[] result = this.DataLoader.Get(type);
   
    //this.dataGridView1.Columns.Clear();
    
    var properties = type.GetProperties();
    
    List<Shell> shells = new List<Shell>();
    foreach (var item in properties)
    {
        shells.Add(new Shell(item.Name));
    }
