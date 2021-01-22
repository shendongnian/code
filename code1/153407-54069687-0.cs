    DateTime dat = (DateTime)dr[dc.ColumnName];
    
    //Not working with Excel 2007
    //cell.DataType = CellValues.Date;
    //cell.CellValue = new CellValue(dat.ToString("s"));
    
    double diff = (dat - new DateTime(1899, 12, 30)).TotalSeconds / 86400.0;
    if (diff > 1)
    {
        cell.DataType = CellValues.Number;
        cell.CellValue = new CellValue(diff.ToString().Replace(",", "."));
    
        if (dat.TimeOfDay == new TimeSpan(0))
        {                                
            cell.StyleIndex = 2;   //Custom Style NumberFormatId = 14 ( d/m/yyyy)
        }
        else
        {
            cell.StyleIndex = 1;   //Custom Style NumberFormatId = 22 (m/d/yyyy H:mm)
        }
    }
    else
    {
        cell.DataType = CellValues.String;
        cell.CellValue = new CellValue(dat.ToString());
    }
