    public void CreateExcel()
    {
    
    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "new sheet name";
                
                // storing Each row and column value to excel sheet  //for example from a grid view
                for (int i = 0; i < GridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < GridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = GridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                string path;
                SelectSavePath.ShowDialog();
                path = SelectSavePath.SelectedPath;
                if(path!=string.Empty)
                workbook.SaveAs(path+FileName+".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
    }
