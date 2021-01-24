    [ComVisible(true)]
    public Int32 SendStringToPrinter(string szPrinterName, string szString)
    {
         ...
    }
    [ComVisible(true)]
    public class PrintHandler
    {
        RawPrinterHelper rph = new RawPrinterHelper();
        [MethodImpl(MethodImplOptions.NoInlining)]
        [ComVisible(true)]
        public Int32 SendStringToPrinter(string text, string printerName)
        {            
            return rph.SendStringToPrinter(printerName, text);
        }
    }
