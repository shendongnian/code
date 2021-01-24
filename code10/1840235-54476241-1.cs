    public static string GetStringValue(this ICell cell)
    {
        switch (cell.CellType)
        {
            case CellType.Numeric:
                if (DateUtil.IsCellDateFormatted(cell)) 
                {
                    try
                    {
                        return cell.DateCellValue.ToString();
                    }
                    catch (NullReferenceException)
                    {
                        return DateTime.FromOADate(cell.NumericCellValue).ToString();
                    }
                }
                return cell.NumericCellValue.ToString();
            case CellType.String:
                return cell.StringCellValue;
    
            case CellType.Boolean:
                return cell.BooleanCellValue.ToString();
    
            default:
                return string.Empty;
        }
    }
