    private bool isDate(Range cell)
        {
            if (cell.NumberFormat.ToString().Contains("/yy"))
            {
                return true;
            }
            return false;
        }
    isDate(worksheet.Cells[irow, icol])
