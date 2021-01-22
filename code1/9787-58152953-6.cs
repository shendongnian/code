    using System;
    using System.Threading;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace GCTestOnOffice
    {
      class Program
      {
        //Don't: private  static Excel.Application ExcelApp = new Excel.Application();
        private static void DoSomething(Excel.Application ExcelApp)
        {
            Excel.Workbook Wb = ExcelApp.Workbooks.Open(@"D:\Aktuell\SampleWorkbook.xlsx");
            Excel.Worksheet NewWs = Wb.Worksheets.Add();
                        
            for (int i = 1; i < 10; i++)
            {
                NewWs.Cells[i, 1] = i;
            }
            Wb.Save();
        }
        public static void Quit(Excel.Application ExcelApp)
        {
            if (ExcelApp != null)
            {
                ExcelApp.Quit(); //Don't forget!!!!!
                ExcelApp = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        static void Main(string[] args)
        {
          {
            Excel.Application ExcelApp = new Excel.Application();
            Thread.Sleep(5000);
            DoSomething(ExcelApp);
            Quit(ExcelApp);
            //ExcelApp goes out of scope, the CLR can and will(!) release Excel
          }
          Console.WriteLine("Input a digit: ");
          int k = Console.Read(); 
        }
      }
    }
