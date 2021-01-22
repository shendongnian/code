    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SpreadsheetGear;
    namespace SpreadsheetGearPrintPreview
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a workbook to preview.
                IWorkbook workbook = Factory.GetWorkbook();
                IWorksheet worksheet = workbook.Worksheets[0];
                worksheet.Name = "MySheet";
                worksheet.Cells["A1:J100"].Formula = "=ROUND(RAND()*ROW()*COLUMN(),0)";
                // Set the print area.
                IPageSetup pageSetup = worksheet.PageSetup;
                pageSetup.PrintArea = "A1:J100";
                // This will force the workbook to be printed on one page.
                pageSetup.FitToPagesTall = 1;
                pageSetup.FitToPagesWide = 1;
                // Create a WorkbookView and display the workbook in Print Preview.
                var workbookView = new SpreadsheetGear.Windows.Forms.WorkbookView(workbook);
                workbookView.PrintPreview();
            }
        }
    }
