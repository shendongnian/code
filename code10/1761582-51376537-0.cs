    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    // namespace, class here
    private void processWorksheet()
    {
        using (var file = new FileStream(@"C:\test.ett", FileMode.Open, FileAccess.Read))
        {
            var workbook = new HSSFWorkbook(file);
            var sheet = workbook.GetSheet("Sheet1");
            // do stuff with worksheet here
        }
    }  
