    using System;
    using SpreadsheetGear;
    namespace WorkbookToCSV
    {
        class Program
        {
            static void Main(string[] args)
            {
                string inputFilename = @"c:\CSVIn.xlsx";
                string outputFilename = @"c:\CSVOut.csv";
                // Create the output stream.
                using (System.IO.FileStream outputStream = new System.IO.FileStream(outputFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    // Load the source workbook.
                    IWorkbook workbook = Factory.GetWorkbook(inputFilename);
                    foreach (IWorksheet worksheet in workbook.Worksheets)
                    {
                        // Save to CSV in a memory buffer and then write it to
                        // the output FileStream.
                        byte[] csvBuffer = worksheet.SaveToMemory(FileFormat.CSV);
                        outputStream.Write(csvBuffer, 0, csvBuffer.Length);
                    }
                    outputStream.Close();
                }
            }
        }
    }
