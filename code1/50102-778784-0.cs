    var columns = dataGridView1.Columns;
    
    var oldColumn = columns.Cast<DataGridViewColumn>()
                           .Single(c => c.DataPropertyName == "Type");
    var index = columns.IndexOf(oldColumn);
    
    var newColumn = new DataGridViewComboBoxColumn();
    newColumn.Name = "Type";
    newColumn.DataSource = Enum.GetValues(typeof(Param.enType));
    newColumn.ValueType = typeof(Param.enType);
    
    columns.RemoveAt(index);
    columns.Insert(index, newColumn);
