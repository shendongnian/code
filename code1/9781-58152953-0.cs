    using System;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace GCTestOnOffice
    {
      class Program
      {
        private  static Excel.Application ExcelApp = new Excel.Application();
        private static void DoTheJob()
        {
            Excel.Workbook Wb = ExcelApp.Workbooks.Open(@"D:\Aktuell\SampleWorkbook.xlsx");
            Excel.Worksheet NewWs = Wb.Worksheets.Add();
                        
            for (int i = 1; i < 10; i++)
            {
                NewWs.Cells[i, 1] = i;
            }
            Wb.Save();
        }
        public static void Quit(Excel.Application TheApp)
        {
            if (TheApp != null)
            {
                TheApp.Quit(); //Don't forget!!!!!
                TheApp = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        static void Main(string[] args)
        {
            DoTheJob();
            Console.WriteLine("Input a digit: ");
            int k = Console.Read();
            Quit(ExcelApp);
        }
      }
    }
