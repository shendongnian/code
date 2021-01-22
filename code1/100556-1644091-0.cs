    DataTable myTable = getYourDataByMagic();
    
    DataGridViewComboBoxColumn box = new DataGridViewComboBoxColumn();
    BindingSource bs = new BindingSource();
    bs.add("choice one");
    bs.add("choice two");
    
    box.HeaderText = "My Choice";
    box.Name = "select";
    box.DataSource = bs;
    box.DataPropertyName = "select";
    
    myTable.Columns.Add(new DataColumn("select"));
    this.dataGridView1.Columns.Add(box);
    this.dataGridView1.DataSource = myTable;
