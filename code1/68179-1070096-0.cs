    _DGV.AutoGenerateColumns = false;
    DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
    textColumn.DataPropertyName = "FooBar";
    textColumn.HeaderText = "Foo/Bar"; // may not need to do this with your DisplayNameAttribute
    _DGV.Columns.Add(textColumn);
    textColumn = new DataGridViewTextBoxColumn();
    textColumn.DataPropertyName = "Baz";
    
    List<MyClass> data = GetMyData();
    _DGV.DataSource = data;
