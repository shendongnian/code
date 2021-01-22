    using Microsoft.Office.Interop.Excel;
    
    int FindFirstBold(Cell cell)
    {    
        Range range = (Range) cell;
        for (int index = 1; index <= range.Text.ToString().Length; index++)
        {
            Characters ch = range.get_Characters(index, 1);
            bool bold = (bool) ch.Font.Bold;
            if(bold) return index;
        }
        return 0;
    }
