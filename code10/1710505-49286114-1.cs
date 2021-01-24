        using (var package = new ExcelPackage(fileInfo)) {    
             var worksheet = package.Workbook.Worksheets.Add("Test");    
             var cell = worksheet.Cells[1, 1];
             cell.Style.WrapText = true;
             cell.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
        
             var r1 = cell.RichText.Add("TextLine1" + "\r\n");
             r1.Bold = true;
             var r2 = cell.RichText.Add("TextLine2" + "\r\n");
             r2.Bold = false;
        
             cell = worksheet.Cells[1, 1];
             var r4 = cell.RichText.Add("TextLine3" + "\r\n");
             r4.Bold = true;
        
             package.Save();
         }
