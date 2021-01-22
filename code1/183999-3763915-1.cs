    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    
    namespace PclFontTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string szPrinterName = @"\\printserver\LaserJet 2420";
    
                StreamReader sr = new StreamReader(@"C:\Fonts\US20HP.FNT");
                string line = (char)27 + "*c32545D";
                line += sr.ReadToEnd();
                line += (char)27 + "*c5F";
    
                PrintRaw.RawFilePrint.SendStringToPrinter(szPrinterName, line);
                
                
            }
        }
    }
