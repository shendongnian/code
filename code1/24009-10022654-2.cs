     DataTable dtTable = new DataTable();
     DataColumn col = new DataColumn("Rfid");
     dtTable.Columns.Add(col);
     DataRow drRow;
    
     Microsoft.Office.Interop.Excel.Application ExcelObj =
            new Microsoft.Office.Interop.Excel.Application();
     Microsoft.Office.Interop.Excel.Workbook theWorkbook =
                ExcelObj.Workbooks.Open(txt_FilePath.Text, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
     Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
     try
     {
         for (int sht = 1; sht <= sheets.Count; sht++)
         {
              Microsoft.Office.Interop.Excel.Worksheet worksheet =
                        (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(sht);
              
              for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
              {
                  Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range("A" + i.ToString(), "B" + i.ToString());
                  System.Array myvalues = (System.Array)range.Cells.Value2;
                  String name = Convert.ToString(myvalues.GetValue(1, 1));
                  if (string.IsNullOrEmpty(name) == false)
                  {
                      drRow = dtTable.NewRow();
                      drRow["Rfid"] = name;
                      dtTable.Rows.Add(drRow);
                  }
              }
                  Marshal.ReleaseComObject(worksheet);
                  worksheet = null;
            }
        return dtTable;
    }
    catch
    {
        throw;
    }
    finally
    {
       // Marshal.ReleaseComObject(worksheet);
        Marshal.ReleaseComObject(sheets);
        Marshal.ReleaseComObject(theWorkbook);
        Marshal.ReleaseComObject(ExcelObj);
        //worksheet = null;
        sheets = null;
        theWorkbook = null;
        ExcelObj = null;
    }
