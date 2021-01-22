    Excel.Worksheet activeSheet = ((Excel.Worksheet)Application.ActiveSheet);
    int endRow = 5;
    int endCol = 6;
    for(int idxRow = 1; idxRow <= endRow; idxRow++)
    {
        for(int idxCol = 1; idxCol <= endCol; idxCol)
        {
            ((Excel.Range)activeSheet.Cells[idxRow, idxCol]).Value2 = "Kilroy wuz here";
        }
    }
