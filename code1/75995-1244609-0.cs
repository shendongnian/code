                FileInfo template = new FileInfo(Path.GetDirectoryName(Application.ExecutablePath)+"\\Template.xlsx");
            try
            {
                using (ExcelPackage xlPackage = new ExcelPackage(strFileName,template))
                {
                    //Enable DEBUG mode to create the xl folder (equlivant to expanding a xlsx.zip file)
                    //xlPackage.DebugMode = true;
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["Sheet1"];
                    worksheet.Name = WorkSheetName;
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        int c = 1;
                        if (r > startRow) worksheet.InsertRow(r);
                        // our query has the columns in the right order, so simply
                        // iterate through the columns
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (row[col].ToString() != null)
                            {
                                worksheet.Cell(r, c).Value = colValue;
                                worksheet.Column(c).Width = 10;
                            }
                            c++;
                        }
                        r++;
                    }
                    // change the sheet view to show it in page layout mode
                    worksheet.View.PageLayoutView = false;
                    // save our new workbook and we are done!
                    xlPackage.Save();
                    xlPackage.Dispose();
                }
            }
