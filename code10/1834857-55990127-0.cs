    // simply write to a column
    var fileLocation = "D:\\Book.xlsx";
    FileInfo fi = new FileInfo(fileLocation);
    int i = 1;
    while (1 == 1)  //ALERT: an infinite loop!
    {
        using (ExcelPackage excelPackage = new ExcelPackage(fi))
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];
            worksheet.Cells[$"A{i}"].Value = "Test " + i.ToString();
            using (var fs = new FileStream(fileLocation, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                fs.Lock(0, fs.Length);
                excelPackage.SaveAs(fs);
                try
                {
                    fs.Unlock(0, fs.Length); // this raises an exception if fs unlocked already by itself
                }
                catch (IOException ex) when (ex.Message.ToLower().StartsWith("the segment is already unlocked.",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    // NOP; just ignore if already unlocked
                }
            }
            i++;
        }
    }
