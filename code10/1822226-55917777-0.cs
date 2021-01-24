        using (ExcelPackage package = new ExcelPackage(stream))
        {    
            string directoryServerPath = // your file saving path in server;
    
            if (!Directory.Exists(directoryServerPath))
              Directory.CreateDirectory(directoryServerPath);                     
            System.IO.DirectoryInfo directoryFiles = new DirectoryInfo(directoryServerPath);
            foreach (FileInfo file in directoryFiles.GetFiles())
            {
             file.IsReadOnly = false;
             file.Delete();
            }
    
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;
        
            for (int row = 1; row <= rowCount; row++)
            {
                for (int col = 1; col <= colCount; col++)
                {
                    //Parse here
                }
            }
    
           package.SaveAs(new System.IO.FileInfo(directoryServerPath + fileName));
                        System.IO.File.SetAttributes(directoryServerPath + fileName, FileAttributes.ReadOnly);
        }
