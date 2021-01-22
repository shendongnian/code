    //the excel sheet as byte array (as example from a FileUpload Control)
    byte[] bin = FileUpload1.FileBytes;
    
    //gen the byte array into the memorystream
    using (MemoryStream ms = new MemoryStream(bin))
    using (ExcelPackage package = new ExcelPackage(ms))
    {
        //get the first sheet from the excel file
        ExcelWorksheet sheet = package.Workbook.Worksheets[1];
    
        //loop all rows in the sheet
        for (int i = sheet.Dimension.Start.Row; i <= sheet.Dimension.End.Row; i++)
        {
            //loop all columns in a row
            for (int j = sheet.Dimension.Start.Column; j <= sheet.Dimension.End.Column; j++)
            {
                //do something with the current cell value
                string currentCellValue = sheet.Cells[i, j].Value.ToString();
            }
        }
    }
