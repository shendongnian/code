    using XL = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    
    public static void Datasource(DataTable dt)
    {
        XL.Application oXL;
        XL._Workbook oWB;
        XL._Worksheet oSheet;
        XL.Range oRng;
        try
        {
            oXL = new XL.Application();
            Application.DoEvents();
            oXL.Visible = false;
            //Get a new workbook.
            oWB = (XL._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (XL._Worksheet)oWB.ActiveSheet;
            //System.Data.DataTable dtGridData=ds.Tables[0];
            int iRow = 2;
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    oSheet.Cells[1, j + 1] = dt.Columns[j].ColumnName;
                }
                // For each row, print the values of each column.
                for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
                {
                    for (int colNo = 0; colNo < dt.Columns.Count; colNo++)
                    {
                        oSheet.Cells[iRow, colNo + 1] = dt.Rows[rowNo][colNo].ToString();
                    }
                    iRow++;
                }
                iRow++;
            }
            oRng = oSheet.get_Range("A1", "IV1");
            oRng.EntireColumn.AutoFit();
            oXL.Visible = true;
        }
        catch (Exception theException)
        {
            throw theException;
        }
        finally
        {
            oXL = null;
            oWB = null;
            oSheet = null;
            oRng = null;
        }
    }
    
