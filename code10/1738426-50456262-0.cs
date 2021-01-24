     void ReadFromExcel(Stream excelFileStream, DataTable dt, int sheetsToRead, out string processingError)
      {
                    // write data in workbook from xls document.
                    XSSFWorkbook workbook = new XSSFWorkbook(excelFileStream);
                    // read the current table data
                    XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(0);
                    // read the current row data
                    XSSFRow headerRow = (XSSFRow)sheet.GetRow(0);
                    // LastCellNum is the number of cells of current rows
                    int cellCount = headerRow.LastCellNum;
                    bool isBlanKRow = false;
                    processingError = "";
                    try
                    {
                        if (dt.Rows.Count == 0)
                        {
                            //Reading First Row as Header for Excel Sheet;
                            try
                            {
                                for (int j = headerRow.FirstCellNum; j < cellCount; j++)
                                {
                                    // get data as the column header of DataTable
                                    DataColumn column = new DataColumn(headerRow.GetCell(j).StringCellValue);
                                    dt.Columns.Add(column);
                                }
                            }
                            catch (Exception Ex)
                            {
                                logger.Error("Error", Ex);
                                processingError = Ex.Message;
                                throw;
                            }
                        }   
 
    
                    // Number of Sheets to Read  
                    for (int sheetindex = 0; sheetindex < sheetsToRead; sheetindex++)
                    {
                        sheet = (XSSFSheet)workbook.GetSheetAt(sheetindex);
                        if (null != sheet)
                        {
    
                            // LastRowNum to get the number of rows of current table
                            int rowCount = sheet.LastRowNum + 1;
                            // Reading Rows and Copying it to Data Table;
                            try
                            {
                                for (int i = (sheet.FirstRowNum + 1); i < rowCount; i++)
                                {
                                    XSSFRow row = (XSSFRow)sheet.GetRow(i);
                                    DataRow dataRow = dt.NewRow();
                                    isBlanKRow = true;
                                    try
                                    {
                                        for (int j = row.FirstCellNum; j < cellCount; j++)
                                        {
                                            if (null != row.GetCell(j) && !string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                                            {
                                                dataRow[j] = row.GetCell(j).ToString();
                                                isBlanKRow = false;
                                            }
                                        }
                                    }
                                    catch (Exception Ex)
                                    {
                                        processingError = Ex.Message;
                                        throw;
                                    }
                                    if (!isBlanKRow)
                                    {
                                        dt.Rows.Add(dataRow);
                                    }
                                }
                            }
                            catch (Exception Ex)
                            {
                                processingError = Ex.Message;
                                throw;
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    processingError = Ex.Message;
                    throw;
                }
                finally
                {
                    workbook.UnlockStructure();
                    workbook.UnlockRevision();
                    workbook.UnlockWindows();
                    workbook = null;
                    sheet = null;
                }
            }
