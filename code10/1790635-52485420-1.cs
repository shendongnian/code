            private void WordRunButton_Click(object sender, EventArgs e)
            {
    
                var excelApp = new excel.Application();
                excel.Workbooks workbooks = excelApp.Workbooks;
                var wordApp = new word.Application();
                word.Documents documents = wordApp.Documents;
                wordApp.Visible = false;
                excelApp.Visible = false;
    
                string[] fileDirectories = Directory.GetFiles(WordSourceBox.Text, "*.doc*",
                       SearchOption.AllDirectories);
    
                foreach (var item in fileDirectories)
                {
                    word._Document document = documents.Open(item);
    
                    foreach (word.Table table in document.Tables)
                    {
                            string wordFile = item;
                            appendName = Path.GetFileNameWithoutExtension(wordFile) + " Table " + tableCount + ".xlsx";
    
                            var workbook = excelApp.Workbooks.Add(1);
                            excel._Worksheet worksheet = (excel.Worksheet)workbook.Sheets[1];
    
                            for (int row = 1; row <= table.Rows.Count; row++)
                            {
                                for (int col = 1; col <= table.Columns.Count; col++)
                                {
    
                                    var cell = table.Cell(row, col);
                                    var range = cell.Range;
                                    var text = range.Text;
    
                                    var cleaned = excelApp.WorksheetFunction.Clean(text);
    
                                    worksheet.Cells[row, col] = cleaned;
                                }
                            }
                            workbook.SaveAs(Path.Combine(WordOutputBox.Text, Path.GetFileName(appendName)), excel.XlFileFormat.xlWorkbookDefault);
    
                            workbook.Close();
                            Marshal.ReleaseComObject(workbook);
                          
                        tableCount++;
                    }
    
                    document.Close();
                    Marshal.ReleaseComObject(document);
                }
                excelApp.Application.Quit();
                workbooks.Close();
                excelApp.Quit();
    
                Marshal.ReleaseComObject(workbooks);
                Marshal.ReleaseComObject(excelApp);
    
                wordApp.Application.Quit();
                wordApp.Quit();
                Marshal.ReleaseComObject(documents);
                Marshal.ReleaseComObject(wordApp);
            }
