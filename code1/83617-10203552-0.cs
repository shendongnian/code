            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); 
            Excel.Hyperlink link =
                (Excel.Hyperlink)
                xlWorkSheet.Hyperlinks.Add(xlWorkSheet.get_Range("L500", Type.Missing), "#Sheet1!B1", Type.Missing,
                                           "Go top",
                                           "UP");
            
            xlWorkSheet.Hyperlinks.Add(xlWorkSheet.get_Range("C5", Type.Missing), "www.google.com", Type.Missing, "Click me to go to Google ","Google.com");                                                     
            xlApp.Visible = true;
