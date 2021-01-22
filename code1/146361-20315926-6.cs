    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    [StructLayout(LayoutKind.Sequential)]
    public struct DOCINFO {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string pDataType;
    }
    public class PrintDirect {
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long ClosePrinter(IntPtr hPrinter);
    }
    private void Print(String printerAddress, String text, String documentName) {
        IntPtr printer = new IntPtr();
    
        // A pointer to a value that receives the number of bytes of data that were written to the printer.
        int pcWritten = 0;
    
        DOCINFO docInfo = new DOCINFO();
        docInfo.pDocName = documentName;
        docInfo.pDataType = "RAW";
    
        PrintDirect.OpenPrinter(printerAddress, ref printer, 0);
        PrintDirect.StartDocPrinter(printer, 1, ref docInfo);
        PrintDirect.StartPagePrinter(printer);
        try {
        PrintDirect.WritePrinter(printer, text, text.Length, ref pcWritten);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
        PrintDirect.EndPagePrinter(printer);
        PrintDirect.EndDocPrinter(printer);
        PrintDirect.ClosePrinter(printer);
    }
