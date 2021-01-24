    for (int row = 12; row <= 26; row++)
    {
        DataRow newRow = dt.NewRow(); //Create a row
        int i = 0;
        for (int col = workSheet.Dimension.Start.Column; 
            col <= workSheet.Dimension.End.Column; col++)
        {
             newRow[i++] = workSheet.Cells[row, col].Text;
        }
        dt.Rows.Add(newRow);                   
    }
