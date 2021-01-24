      DataTable table = new DataTable();
    
          private void ReadExcel(string filePath)
          {
        
                      if (!string.IsNullOrEmpty(filePath))
                      {
                              ExcelEngine excelEngine = new ExcelEngine();
        
                             IWorkbook workbook = excelEngine.Excel.Workbooks.Open(filePath);
                                  IWorksheet worksheet = workbook.Worksheets[0];
        
                            table = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                                  YourDatagridviewName.DataSource = table;
                                  YourDatagridviewName.Refresh();
                      }
                      else
                      {
                                  MessageBox.Show("No File Selected");
                      }
        
          }
