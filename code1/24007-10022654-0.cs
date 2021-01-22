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
    
    Import from Excel to datatable
    
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
