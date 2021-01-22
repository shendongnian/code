    dataGridView1.AutoGenerateColumns = false;
    _users = new BindingList<User>();
    _users .Add(new Names() { Name = "joe", id=1 });
    _users .Add(new Names() { Name = "pete", id = 2 });
    
    bindingSource1.DataSource = _names;
    
    DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
    col1.DataPropertyName = "Name";        
    
    dataGridView1.Columns.Add(col1);
                
    dataGridView1.DataSource = _users;
