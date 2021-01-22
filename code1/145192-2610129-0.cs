    Excel.Range cell = (Excel.Range)sheet.UsedRange[row, col];
    if (cell.Value2 != null)
    {
        switch (Type.GetTypeCode(cell.Value2.GetType()))
        {
            case TypeCode.String:
                string formula = cell.Value2;
                break;
            case TypeCode.Double:
                double amt = (Double)cell.Value2;
                break;
        }
    }
    
    cell.Value2 = amt + someotheramt;
