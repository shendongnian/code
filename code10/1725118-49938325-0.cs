                // no need to open another Excel instance
                Microsoft.Office.Interop.Excel.Application xlApp = Globals.ThisAddIn.Application;
                // get the name of the active workbook to be able to return back
                var activeWkbName = xlApp.ActiveWorkbook.Name;
                
                // open the template workbook - which will become active then
                var templateWorkbook = xlApp.Workbooks.Open(templatePath);
                var from = (templateWorkbook.Sheets[1] as Microsoft.Office.Interop.Excel.Worksheet); 
    
                // active the original one
                xlApp.Workbooks[activeWkbName].Activate();
                from.Copy(xlApp.ActiveWorkbook.ActiveSheet, Type.Missing);
