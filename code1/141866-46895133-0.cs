           static void ExcelToCSVCoversion(string sourceFile,  string targetFile)
        {
            Application rawData = new Application();
            try
            {
                Workbook workbook = rawData.Workbooks.Open(sourceFile);
                Worksheet ws = (Worksheet) workbook.Sheets[1];
                ws.SaveAs(targetFile, XlFileFormat.xlCSV);
                Marshal.ReleaseComObject(ws);
            }
            finally
            {
                rawData.DisplayAlerts = false;
                rawData.Quit();
                Marshal.ReleaseComObject(rawData);
            }
            Console.WriteLine();
            Console.WriteLine($"The excel file {sourceFile} has been converted into {targetFile} (CSV format).");
            Console.WriteLine();
        }
