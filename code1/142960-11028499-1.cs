     // Add references for: COM:  Microsoft Internet Controls; .NET: System.Management.dll
    using System;
    using System.Reflection;
    using System.Threading;
    using SHDocVw;
    using System.Windows.Controls;
    using System.Management;
    
    namespace HTMLPrinting
    {
       public class HTMLPrinter
       {
          private bool documentLoaded;
          private bool documentPrinted;
          private string originalDefaultPrinterName;
    
          private void ie_DocumentComplete(object pDisp, ref object URL)
          {
             documentLoaded = true;
          }
    
          private void ie_PrintTemplateTeardown(object pDisp)
          {
             documentPrinted = true;
          }
    
          public void Print(string htmlFilename, string printerName)
          { 
             // Preserve default printer name
             originalDefaultPrinterName = GetDefaultPrinterName();
             // set new default printer
             SetDefaultPrinter(printerName);
             // print to printer
             Print(htmlFilename);
          }
    
          public void Print(string htmlFilename)
          {
             documentLoaded = false;
             documentPrinted = false;
    
             InternetExplorer ie = new InternetExplorer();
             ie.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(ie_DocumentComplete);
             ie.PrintTemplateTeardown += new DWebBrowserEvents2_PrintTemplateTeardownEventHandler(ie_PrintTemplateTeardown);
    
             object missing = Missing.Value;
    
             ie.Navigate(htmlFilename, ref missing, ref missing, ref missing, ref missing);
             while (!documentLoaded && ie.QueryStatusWB(OLECMDID.OLECMDID_PRINT) != OLECMDF.OLECMDF_ENABLED)
                Thread.Sleep(100);
    
             ie.ExecWB(OLECMDID.OLECMDID_PRINT, OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ref missing, ref missing);
    
             // Wait until the IE is done sending to the printer
             while (!documentPrinted)
                Thread.Sleep(100);
    
             // Remove the event handlers
             ie.DocumentComplete -= ie_DocumentComplete;
             ie.PrintTemplateTeardown -= ie_PrintTemplateTeardown;
             ie.Quit();
    
             // reset to original default printer if needed
             if (GetDefaultPrinterName() != originalDefaultPrinterName)
             {
                SetDefaultPrinter(originalDefaultPrinterName);
             }
          }
    
          public static string GetDefaultPrinterName()
          {
             var query = new ObjectQuery("SELECT * FROM Win32_Printer");
             var searcher = new ManagementObjectSearcher(query);
    
             foreach (ManagementObject mo in searcher.Get())
             {
                if (((bool?)mo["Default"]) ?? false)
                {
                   return mo["Name"] as string;
                }
             }
    
             return null;
          }
    
          public static bool SetDefaultPrinter(string defaultPrinter)
          {
              using (ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer"))
              {
                  using (ManagementObjectCollection objectCollection = objectSearcher.Get())
                  {
                      foreach (ManagementObject mo in objectCollection)
                      {
                          if (string.Compare(mo["Name"].ToString(), defaultPrinter, true) == 0)
                          {
                              mo.InvokeMethod("SetDefaultPrinter", null, null);
                              return true;
                          }
                      }
                  }
              }
              return true;
          }
       }
    }
