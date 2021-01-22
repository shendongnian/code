private void Print(String printerAddress, String text, String documentName)
{
    IntPtr printer = new IntPtr();
    
    // A pointer to a value that receives the number of bytes of data that were written to the printer.
    int pcWritten = 0;
    
    DOCINFO docInfo = new DOCINFO();
    docInfo.pDocName = documentName;
    docInfo.pDataType = "RAW";
    
    PrintDirect.OpenPrinter(printerAddress, ref printer, 0);
    PrintDirect.StartDocPrinter(printer, 1, ref docInfo);
    PrintDirect.StartPagePrinter(printer);
    try
    {
        PrintDirect.WritePrinter(printer, text, text.Length, ref pcWritten);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    PrintDirect.EndPagePrinter(printer);
    PrintDirect.EndDocPrinter(printer);
    PrintDirect.ClosePrinter(printer);
}
