    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management;
    using System.IO;
    
    namespace SyTest
    {
      class Program
      {
        static StreamWriter specStream;
    
        static void Main(string[] args)
        {
          FileStream specFile =
              new FileStream("machine-specs.txt",FileMode.Create,FileAccess.Write);
          specStream = new StreamWriter(specFile);
    
          LogClass("Win32_DesktopMonitor");
          LogClass("Win32_VideoController");
          LogClass("Win32_Processor");
          // etc
    
          specStream.Close();
          specFile.Close();
        }
    
        static void LogClass(string strTable)
        {
          if (strTable.Length <= 0) return;
          specStream.Write("--- " + strTable + " ---\r\n\r\n");
          WqlObjectQuery wqlQuery =
              new WqlObjectQuery("SELECT * FROM " + strTable);
          ManagementObjectSearcher searcher =
              new ManagementObjectSearcher(wqlQuery);
          try
          {
            if (searcher.Get().Count <= 0)
            {
              specStream.Write("Class has no instances\r\n\r\n");
            }
            foreach (ManagementObject obj in searcher.Get())
            {
              specStream.Write("* " + obj.ToString() + "\r\n");
    
              if (obj.Properties.Count <= 0)
              {
                specStream.Write("Class instance has no properties\r\n");
                continue;
              }
    
              foreach (System.Management.PropertyData prop in obj.Properties)
              {
                LogAttr(obj, prop.Name);
              }
    
              specStream.Write("\r\n");
            }
          }
          catch { specStream.Write("Class does not exist\r\n\r\n"); }
        }
        static void LogAttr(ManagementObject obj, string str)
        {
          if (str.Length <= 0) return;
          string strValue = "";
          try
          {
            strValue = obj[str].ToString();
            try
            {
              string[] pstrTmp = ((string[])obj[str]);
              if (pstrTmp.Length > 0) strValue = String.Join(", ", pstrTmp);
            }
            catch { } // Problem casting, fall back on original assignment
          }
          catch { strValue = "[UNDEFINED]"; }
          specStream.Write(str + ": " + strValue + "\r\n");
        }
      }
    }
