                Excel.Application mainApp = new Excel.ApplicationClass();
                mainApp.Visible = false;
                Excel.Workbook mainWorkbook = excelApp.Workbooks.Add(null);
                Excel.Sheets mainWorkSheets = mainWorkbook.Worksheets;
                
                foreach (string i in files)
                {
                    MessageBox.Show("1 " + i);
                    Excel.Application exApp = new Excel.ApplicationClass();
                    exApp.Visible = false;
                    MessageBox.Show("2 " + i);
                    Excel.Workbook exWorkbook = exApp.Workbooks.Open(i,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    MessageBox.Show("3 " + i);
                    foreach(Excel.Worksheet sheet in exWorkbook.Worksheets)
                    {
                        sheet.Copy(Type.Missing, mainWorkSheets[mainWorkSheets.Count -1]);
                    }
                }
                mainApp.Save("NewExcel");
