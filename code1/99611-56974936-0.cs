    static void PrintProps(ManagementObject o, string prop)
    {
        try { Console.WriteLine(prop + "|" + o[prop]); }
        catch (Exception e) { Console.Write(e.ToString()); }
    }
    static void Main(string[] args)
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
        foreach (ManagementObject printer in searcher.Get())
        {
            string printerName = printer["Name"].ToString().ToLower();
            Console.WriteLine("Printer :" + printerName);
            PrintProps(printer, "Caption");
            PrintProps(printer, "ExtendedPrinterStatus");
            PrintProps(printer, "Availability");
            PrintProps(printer, "Default");
            PrintProps(printer, "DetectedErrorState");
            PrintProps(printer, "ExtendedDetectedErrorState");
            PrintProps(printer, "ExtendedPrinterStatus");
            PrintProps(printer, "LastErrorCode");
            PrintProps(printer, "PrinterState");
            PrintProps(printer, "PrinterStatus");
            PrintProps(printer, "Status");
            PrintProps(printer, "WorkOffline");
            PrintProps(printer, "Local");
        }
    }
