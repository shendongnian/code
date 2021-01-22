    public Excel.Style xlStyleHeader = null;
    private void CreateHeaderStyle()
    {
        Excel.Styles xlStyles = null;
        Excel.Font xlFont = null;
        Excel.Interior xlInterior = null;
        Excel.Borders xlBorders = null;
        Excel.Border xlBorderBottom = null;
        try
        {
            xlStyles = xlWorkbook.Styles;
            xlStyleHeader = xlStyles.Add("Header", Type.Missing);
            // Text Format
            xlStyleHeader.NumberFormat = "@";
            // Bold
            xlFont = xlStyleHeader.Font;
            xlFont.Bold = true;
            // Light Gray Cell Color
            xlInterior = xlStyleHeader.Interior;
            xlInterior.Color = 12632256;
            // Medium Bottom border
            xlBorders = xlStyleHeader.Borders;
            xlBorderBottom = xlBorders[Excel.XlBordersIndex.xlEdgeBottom];
            xlBorderBottom.Weight = Excel.XlBorderWeight.xlMedium;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Release(xlBorderBottom);
            Release(xlBorders);
            Release(xlInterior);
            Release(xlFont);
            Release(xlStyles);
        }
    }
    private void Release(object obj)
    {
        if (obj != null)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
    }
