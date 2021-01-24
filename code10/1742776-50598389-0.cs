    System.Drawing.Color HeaderColor = System.Drawing.Color.FromArgb(_,_,_);
    System.Drawing.Color OddRowColor = System.Drawing.Color.FromArgb(_,_,_);
    System.Drawing.Color EvenRowColor = System.Drawing.Color.FromArgb(_,_,_);
    
    int ColumnCount = _;
    int RowCount = _;
    
    workSheet.Cells[1, 1, 1, ColumnCount].Style.Font.Color.SetColor(HeaderColor);
    
    for(int i=2; i<=RowCount; i++)
    {
        var currentColor = i%2 == 1 ? OddRowColor : EvenRowColor;
        workSheet.Cells[i, 1, i, ColumnCount].Style.Font.Color.SetColor(currentColor);
    }
