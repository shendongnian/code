    Excel.Workbook xlWorkBook;
        Excel.Application xlApp;
        Excel.Worksheet xlWorkSheet;
        Excel.Range Startrange;
        Excel.Range HeaderStartrange;
        public bool StartExport(DataTable dtbl, bool isFirst, bool isLast, string strOutputPath, string TemplateLocation, string TemplateFullName, int SectionOrder, int totalNoOfSheets)
        {
            bool isSuccess = false;
            try
            {
                if (isFirst)
                {
                    CopyTemplate(TemplateLocation, strOutputPath, TemplateFullName);
                    xlApp = new Excel.Application();
                    if (xlApp == null)
                    {
                        throw new Exception("Excel is not properly installed!!");
                    }
                    xlWorkBook = xlApp.Workbooks.Open(@strOutputPath + TemplateFullName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    // To Add Sheets Dynamically
                    for (int i = 0; i <= totalNoOfSheets; i++)
                    {
                        int count = xlWorkBook.Worksheets.Count;
                        Excel.Worksheet addedSheet = xlWorkBook.Worksheets.Add(Type.Missing,
                                xlWorkBook.Worksheets[count], Type.Missing, Type.Missing);
                        addedSheet.Name = "Sheet " + i.ToString();
                    }
                }
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(SectionOrder);
                Startrange = xlWorkSheet.get_Range("A2");
                HeaderStartrange = xlWorkSheet.get_Range("A1");
                FillInExcel(Startrange, HeaderStartrange, dtbl);
                xlWorkSheet.Name = dtbl.TableName;
                if (isLast)
                {
                    xlApp.DisplayAlerts = false;
                    xlWorkBook.SaveAs(@strOutputPath + TemplateFullName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                    xlWorkBook.Close(true, null, null);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                throw;
            }
            return isSuccess;
        }
            private void FillInExcel(Excel.Range startrange, Excel.Range HeaderStartRange, DataTable dtblData)
        {
            int rw = 0;
            int cl = 0;
            try
            {
                // Fill The Report Content Data Here
                rw = dtblData.Rows.Count;
                cl = dtblData.Columns.Count;
                string[,] data = new string[rw, cl];
                // Adding Columns Here
                for (var row = 1; row <= rw; row++)
                {
                    for (var column = 1; column <= cl; column++)
                    {
                        data[row - 1, column - 1] = dtblData.Rows[row - 1][column - 1].ToString();
                    }
                }
                Excel.Range endRange = (Excel.Range)xlWorkSheet.Cells[rw + (startrange.Cells.Row - 1), cl + (startrange.Cells.Column - 1)];
                Excel.Range writeRange = xlWorkSheet.Range[startrange, endRange];
                writeRange.Value2 = data;
                writeRange.Formula = writeRange.Formula;
                data = null;
                startrange = null;
                endRange = null;
                writeRange = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
