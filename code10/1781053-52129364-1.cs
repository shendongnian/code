    //loop through rows and columns
    for (int row = 1; row <= rowCount; row++)
    {
        //create a bool
        bool RowIsEmpty = true;
    
        for (int col = 1; col <= colCount; col++)
        {
            //check if the cell is empty or not
            if (worksheet.Cells[row, col].Value != null)
            {
                RowIsEmpty = false;
            }
        }
    
        //display result
        if (RowIsEmpty)
        {
            Label1.Text += "Row " + row + " is empty.<br>";
        }
    }
