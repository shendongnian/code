                    var excelApp = new Application();
                    excelApp.Workbooks.Open("c:\\Test.xls",Type.Missing,Type.Missing,
                                                           Type.Missing,Type.Missing,
                                                           Type.Missing,Type.Missing,
                                                           Type.Missing,Type.Missing,
                                                           Type.Missing,Type.Missing,
                                                           Type.Missing,Type.Missing,
                                                           Type.Missing,Type.Missing);
                    var ws = excelApp.Worksheets;
                    var worksheet =(Worksheet) ws.get_Item("Sheet1");
                    Range range = worksheet.UsedRange;
                    // In the following cases Value2 returns different types
                    // 1. the range variable points to a single cell
                    // Value2 returns a object
                    // 2. the range variable points to many cells
                    // Value2 returns object[,]
                    
                    object[,] values = (object[,])range.Value2;
                    for (int row = 1; row <= values.GetUpperBound(0); row++)
                        for (int col = 1; col <= values.GetUpperBound(1); col++)
                    {
                        string value = Convert.ToString(values[row, col]);
                        //Also used a different regex, found yours not to match on your given criteria
                        if (Regex.IsMatch(value, @"^\d{3}-\d{2}-\d{4}$"))
                        {
                            range.Cells.set_Item(row,col,"0");
                        }
                    }
               
                excelApp.Save("C:\\Out.xls");
                excelApp.Quit();
         
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(ws);
                Marshal.ReleaseComObject(excelApp);
