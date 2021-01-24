    // The clipboard row works only for visible cells
    // To obtain the data column use the columnIndex and then map that to the Columns collection
    int columnIndex = dataGrid.CurrentCell.Column.DisplayIndex;
    var column = dataGrid.Columns[columnIndex];
    
    // Now get the needed column 
    var cellContent = clipboardRowContent.Where(i => i.Column == column).First();
    clipboardRowContent.Clear();
    clipboardRowContent.Add(cellContent);
