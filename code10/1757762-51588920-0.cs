     Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Workbook workb = app.Workbooks.Open("c:\\Users\\Jack\\Documents\\Document1.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workb.Sheets[1];
               // worksheet = workbook.Sheets[1];
                //worksheet = workbook.ActiveSheet;
                //worksheet.Name = "birinchi";
                
    
    
    
                for (int i = 0; i < Table.Columns.Count; i++) 
                {
                 //   worksheet.Cells[1, i+1] = Table.Columns[i].Header;
                    
                }
    
    
                    for (int i = 0; i < Table.Columns.Count; i++)
                    {
    
                        for (int j = 0; j < Table.Items.Count; j++)
                        {
                            TextBlock b = Table.Columns[i].GetCellContent(Table.Items[j]) as TextBlock;
                            worksheet.Cells[j + 2, i + 1] = b.Text;
                            //MessageBox.Show(b.Text);
                           
                        }
                    }
                    
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "Document";
                    dlg.DefaultExt = ".xlsx";
                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
    
                       workbook.SaveAs(dlg.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
    
                        
                    }
                    app.Quit();
                   
                
            
