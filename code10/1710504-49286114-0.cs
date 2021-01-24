        using (var package = new ExcelPackage(fileInfo)) {    
             var worksheet = package.Workbook.Worksheets.Add("Test");    
             var cell = worksheet.Cells[1, 1];
             cell.Style.WrapText = true;
             cell.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
        
             var r1 = cell.RichText.Add("TextLine1" + "\r\n");
             r1.Bold = true;
             var r2 = cell.RichText.Add("TextLine2" + "\r\n");
             r2.Bold = false;
        
             package.Save();
         }
