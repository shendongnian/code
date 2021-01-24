    // define your colors (header, odd rows, even rows)
    System.Drawing.Color HeaderColor = System.Drawing.Color.FromArgb(_,_,_);
    System.Drawing.Color OddRowColor = System.Drawing.Color.FromArgb(_,_,_);
    System.Drawing.Color EvenRowColor = System.Drawing.Color.FromArgb(_,_,_);
    
    // get the column/row count
    int ColumnCount = _;
    int RowCount = _;
    
    // set the header color
    var firstHeaderCell = workSheet.Cells[1, 1];
    var lastHeaderCell = workSheet.Cells[1, ColumnCount];
    workSheet.Range[firstHeaderCell, lastHeaderCell].Interior.Color = 
        System.Drawing.ColorTranslator.ToOle(HeaderColor);
    
    // loop through all the rows
    for(int i=2; i<=RowCount; i++)
    {
        var currentColor = i%2 == 1 ? OddRowColor : EvenRowColor;
        var firstRowCell = workSheet.Cells[i, 1];
        var lastRowCell = workSheet.Cells[i, ColumnCount];
        // set row color based on i being even or odd
        workSheet.Range[firstRowCell, lastRowCell].Interior.Color =
            System.Drawing.ColorTranslator.ToOle(currentColor);
    }
