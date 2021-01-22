    using System;
    using System.Management;
    
    public class MyClass
    {
          
          static void printProps(ManagementObject o,string prop){
                try{Console.WriteLine(prop+"|"+o[prop]);}catch(Exception e){Console.Write(e.ToString());}
          }
          
          [STAThread]
          static void Main(string[] args) 
          {
            ManagementObjectSearcher searcher = new 
            ManagementObjectSearcher("SELECT * FROM Win32_Printer where Default=True");
          
            string printerName = "";
            foreach (ManagementObject printer in searcher.Get()){
              printerName = printer["Name"].ToString().ToLower();
                Console.WriteLine("Printer :"+printerName);
                printProps(printer, "WorkOffline");
                //Console.WriteLine();
                switch( Int32.Parse( printer["PrinterStatus"].ToString() )){
                      case 1: Console.WriteLine("Other"); break;
                      case 2: Console.WriteLine("Unknown");break;
                      case 3: Console.WriteLine("Idle"); break;
                      case 4: Console.WriteLine("Printing"); break;
                      case 5: Console.WriteLine("Warmup"); break;
                      case 6: Console.WriteLine("Stopped printing"); break;
                      case 7: Console.WriteLine("Offline"); break;
                }
            }
          }
    }
