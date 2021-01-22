    // Create header and set up image
    YourDataGridViewColumnHeaderCell headerCell = new YourDataGridViewColumnHeaderCell();
    headerCell.Image = something;
    
    // Create column
    DataGridViewColumn yourColumn = new DataGridViewTextBoxColumn(); 
    // ...
    yourColumn.ColumnHeaderCell = new headerCell;
