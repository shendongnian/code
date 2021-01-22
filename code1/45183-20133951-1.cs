    // using System.Dynamic;
    
    DataGrid dataGrid;
    
    string[] labels = new string[] { "Column 0", "Column 1", "Column 2" };
    
    foreach (string label in labels)
    {
        DataGridTextColumn column = new DataGridTextColumn();
        column.Header = label;
        column.Binding = new Binding(label.Replace(' ', '_'));
    
        dataGrid.Columns.Add(column);
    }
    
    int[] values = new int[] { 0, 1, 2 };
    
    dynamic row = new ExpandoObject();
    
    for (int i = 0; i < labels.Length; i++)
        ((IDictionary<String, Object>)row)[labels[i].Replace(' ', '_')] = values[i];
    
    dataGrid.Items.Add(row);
