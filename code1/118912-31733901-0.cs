    foreach (String s in columnNames)
    {
    var item = new MenuItem { IsCheckable = true, IsChecked = true ,Header=s};
    AddColumnsContextMenu.Items.Add(item);
    }
