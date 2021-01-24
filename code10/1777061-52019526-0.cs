    public static Int32 SendStringToPrinter(string szPrinterName, string szString)   
    {
         ...
    }
    public class PrintHandler
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Int32 SendStringToPrinter(string text, string printerName)
        {            
            return RawPrinterHelper.SendStringToPrinter(printerName, text);
        }
    }
