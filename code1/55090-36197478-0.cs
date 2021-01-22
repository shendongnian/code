    var printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
    
    int printerIndex = 0;
    
    foreach(String s in printers)
    {
        if (s.Equals("Name of Printer"))
        {
            break;
        }
        printerIndex++;
    }
    
    xlWorkBook.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing,printers[printerIndex], Type.Missing, Type.Missing, Type.Missing);
