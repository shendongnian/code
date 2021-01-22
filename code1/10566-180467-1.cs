    static const int INDENTCOEFF = 5;
    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
        
    cellStyle.Padding = 
             new Padding(INDENTCOEFF , 5, INDENTCOEFF , 5); //left,top,right,bottom
    MyColumn.DefaultCellStyle = cellStyle;
    MyColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
