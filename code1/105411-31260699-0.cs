                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlWorkBook = ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                
                for (int i = 1; i > 0; i--)
                {
                    Sheets xlSheets = null;
                    Worksheet xlWorksheet = null;
                    //Create Excel sheet
                    xlSheets = ExcelApp.Sheets;
                    xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                    xlWorksheet.Name = "MY FIRST EXCEL FILE";
                    for (int j = 1; j < dtDataTable1.Columns.Count + 1; j++)
                    {
                        ExcelApp.Cells[i, j] = dtDataTable1.Columns[j - 1].ColumnName;
                        ExcelApp.Cells[1, j].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                        ExcelApp.Cells[i, j].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                    }
                    // for the data of the excel
                    for (int k = 0; k < dtDataTable1.Rows.Count; k++)
                    {
                        for (int l = 0; l < dtDataTable1.Columns.Count; l++)
                        {
                            ExcelApp.Cells[k + 2, l + 1] = dtDataTable1.Rows[k].ItemArray[l].ToString();
                        }
                    }
                    ExcelApp.Columns.AutoFit();
                }
                ((Worksheet)ExcelApp.ActiveWorkbook.Sheets[ExcelApp.ActiveWorkbook.Sheets.Count]).Delete();
                ExcelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
