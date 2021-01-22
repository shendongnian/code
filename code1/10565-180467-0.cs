    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
    
    cellStyle.Padding = new Padding(5, 5, 5, 5); // left, top, right, bottom
    MyColumn.DefaultCellStyle = cellStyle;
    MyColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
