    using Microsoft.Office.Interop.Excel;
    
    int FindFirstBold(Range cell)
    {    
        for (int index = 1; index <= cell.Text.ToString().Length; index++)
        {
            Characters ch = cell.get_Characters(index, 1);
            bool bold = (bool) ch.Font.Bold;
            if(bold) return index;
        }
        return 0;
    }
