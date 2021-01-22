    using System.Drawing.Printing;
    namespace MyNamespace
    {
      public class MyPrintManager
      {
        public static PrinterSettings MyPrinterSettings = new PrinterSettings();
        public static string Default_PrinterName
        {
          get
          {
            return MyPrinterSettings.PrinterName;
          }
          set
          {
            MyPrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName = value;
            MyPrinterSettings.PrinterName = value;
          }
        }
      }
    }
