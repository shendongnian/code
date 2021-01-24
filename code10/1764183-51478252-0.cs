    private void button_Click(object sender, EventArgs e)
    {
    	var fileName = @"myexcel.xlsx";
    
    
        if (File.Exists(fileName))
        {
            try
            {
                var excelApp = new Excel.Application();
                var xlWorkBook = excelApp.Workbooks.Open(fileName);
    
                var xlWorkSheet = (Excel.Worksheet)excelApp.ActiveSheet;
                xlWorkSheet.Cells[1, "A"] = "Some thing";
                xlWorkSheet.Cells[1, "B"] = "Other thing";
                xlWorkSheet.SaveAs(fileName);
            }
            catch (Exception ex)
            {
                //some error handling;
            }
        }
    }
