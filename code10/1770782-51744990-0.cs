            public static void ExportSheets(string documentFilePath, List<IWorkbook> workbooks)
            {
                if (workbooks.Count > 0)
                {
                    var destinationWorkbook = workbooks[0];
    
                    for (var i = 1; i < workbooks.Count; i++)
                    {
                        var sourceWorkBook = workbooks[i];
                        for (var j = 0; j < sourceWorkBook.Sheets.Count; j++)
                        {
                            sourceWorkBook.Sheets[j].CopyAfter(destinationWorkbook.Sheets[destinationWorkbook.Sheets.Count - 1]);
                        }
                    }
                    destinationWorkbook.WindowInfo.DisplayWorkbookTabs = true;
                    destinationWorkbook.SaveAs(documentFilePath, FileFormat.OpenXMLWorkbook);
                }
            }
