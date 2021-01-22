    using Excel = Microsoft.Office.Interop.Excel;
    
    string workbookPath= @"C:\temp\Results_2013Apr02_110133_6692.xml";
                
                this.lblResultFile.Text = string.Format(@" File:{0}",workbookPath);
                if (File.Exists(workbookPath))
                {
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Visible = true;
                    Excel.Workbook excelWorkbook = excelApp.Workbooks.OpenXML(workbookPath, Type.Missing, Excel.XlXmlLoadOption.xlXmlLoadPromptUser);
                }
                else
                {
                    MessageBox.Show(String.Format("File:{0} does not exists", workbookPath));
                }
