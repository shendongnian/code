      try
            {
                FileInfo newFile = new FileInfo(@"D:\ExcelFromTemplate.xlsx");
                FileInfo template = new FileInfo(@"C:\Example.xlsx");
                using (ExcelPackage xlPackage = new ExcelPackage(newFile , template))
                {
                   //Added This part
                   foreach (ExcelWorksheet aworksheet in xlPackage.Workbook.Worksheets)
                    {
                        aworksheet.Cell(1, 1).Value = aworksheet.Cell(1, 1).Value;
                    }
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["My Data"];
                    ExcelCell cell = worksheet.Cell(5, 1);
                    cell.Value = "15";
                    //worksheet.Cell(5, 1).Value = "Soap";
                    xlPackage.Save( );
                    //Response.Write("Excel file created successfully");
                }
            }
            catch (Exception ex)
            {
                //Response.WriteFile(ex.InnerException.ToString());
            }
