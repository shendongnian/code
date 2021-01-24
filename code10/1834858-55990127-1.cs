    //simply populate a list reading excel
    var fileLocation = "D:\\Book.xlsx";
    FileInfo fi = new FileInfo(fileLocation);
    List<string> list = new List<string>();
    ExcelWorksheet worksheet = null;
    int i = 1;
    while (1 == 1)  //ALERT: an infinite loop!
    {
        try
        {
            using (ExcelPackage excelPackage = new ExcelPackage(fi))
            {
                worksheet = excelPackage.Workbook.Worksheets["Sheet1"];
                if (worksheet.Cells[i, 1].Value != null)
                {
                    list.Add(worksheet.Cells[i, 1].Value.ToString());
                }
                Console.WriteLine(worksheet.Dimension.Rows.ToString()); // just prove that it read
            }
        }
        catch (Exception ex) when (
            ex is IOException &&
            ex.Message.StartsWith("The process cannot access the file because another process has locked a portion of the file.", StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine($"Attempt: {i}");
        }
        list.Clear();
    }
